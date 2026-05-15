#version 330 core

uniform vec3 lightPos;
uniform vec3 viewPos;

uniform vec3 Ka;
uniform vec3 Kd;
uniform vec3 Ks;
uniform float Ns;

uniform sampler2D imagem;

varying vec2 out_texture;
varying vec3 out_fragPos;
varying vec3 out_normal;

void main()
{
    vec3 lightColor = vec3(1.0, 1.0, 1.0);

    vec3 ambient = Ka * lightColor;

    vec3 norm = normalize(out_normal);

    vec3 lightDir = normalize(lightPos - out_fragPos);

    float diff = max(dot(norm, lightDir), 0.0);

    vec3 diffuse = Kd * diff * lightColor;

    vec3 viewDir = normalize(viewPos - out_fragPos);

    vec3 reflectDir = reflect(-lightDir, norm);

    float spec = pow(max(dot(viewDir, reflectDir), 0.0), Ns);

    vec3 specular = Ks * spec * lightColor;

    vec4 texColor = texture(imagem, out_texture);

    vec3 lighting = ambient + diffuse + specular;

    gl_FragColor = vec4(lighting, 1.0) * texColor;
}