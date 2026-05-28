#version 330 core

#define NUM_LIGHTS 3

uniform vec3 lightPos[NUM_LIGHTS];
uniform vec3 lightColor[NUM_LIGHTS];
uniform int lightEnvironment[NUM_LIGHTS];

uniform int environment_id;

uniform vec3 viewPos;

uniform vec3 Ka;
uniform vec3 Kd;
uniform vec3 Ks;
uniform float Ns;

uniform sampler2D imagem;

// Vetor de booleanos:
// [0] = ambiente
// [1] = difusa
// [2] = especular
uniform bool enabledLightTypes[3];

in vec2 out_texture;
in vec3 out_fragPos;
in vec3 out_normal;

out vec4 FragColor;

void main()
{
    vec4 texColor = texture(imagem, out_texture);

    if(texColor.a < 0.1)
        discard;

    vec3 norm = normalize(out_normal);

    vec3 viewDir = normalize(viewPos - out_fragPos);

    vec3 ambient = vec3(0.0);

    if(enabledLightTypes[0])
        ambient = Ka;

    vec3 finalDiffuse = vec3(0.0);
    vec3 finalSpecular = vec3(0.0);

    for(int i = 0; i < NUM_LIGHTS; i++)
    {
        if(lightEnvironment[i] != environment_id && environment_id != 0)
            continue;

        vec3 lightDir = normalize(lightPos[i] - out_fragPos);

        float distance = length(lightPos[i] - out_fragPos);

        distance *= 2.0;

        float attenuation = 1.0 / (
            1.0 +
            0.014 * distance +
            0.0007 * distance * distance
        );

        // Difusa
        if(enabledLightTypes[1])
        {
            float diff = max(dot(norm, lightDir), 0.0);

            vec3 diffuse = Kd * diff * lightColor[i];

            diffuse *= attenuation;

            finalDiffuse += diffuse;
        }

        // Especular
        if(enabledLightTypes[2])
        {
            vec3 reflectDir = reflect(-lightDir, norm);

            float spec = pow(max(dot(viewDir, reflectDir), 0.0), Ns);

            vec3 specular = Ks * spec * lightColor[i];

            specular *= attenuation;

            finalSpecular += specular;
        }
    }

    vec3 lighting = ambient + finalDiffuse + finalSpecular;

    FragColor = vec4(lighting, 1.0) * texColor;
}