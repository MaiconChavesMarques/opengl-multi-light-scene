#version 330 core

// atributos recebidos do Python/VBO
in vec3 position;
in vec2 texture_coord;
in vec3 normal;

// enviados para o fragment shader
out vec2 out_texture;
out vec3 out_normal;
out vec3 out_fragPos;

// matrizes
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    // posição do vértice no mundo
    vec4 worldPos = model * vec4(position, 1.0);

    // envia posição fragmento
    out_fragPos = vec3(worldPos);

    // transforma normal corretamente
    out_normal = mat3(transpose(inverse(model))) * normal;

    // envia coordenada de textura
    out_texture = texture_coord;

    // posição final
    gl_Position = projection * view * worldPos;
}