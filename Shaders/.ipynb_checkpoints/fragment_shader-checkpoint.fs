#version 330 core

uniform vec4 color;
uniform int use_color;

varying vec2 out_texture;
varying vec3 out_fragPos;
varying vec3 out_normal;

uniform sampler2D imagem;

void main(){

    vec4 tex_color;

    if (use_color == 1)
        tex_color = color;
    else
        tex_color = texture2D(imagem, out_texture);

    vec3 normal = normalize(out_normal);

    gl_FragColor = tex_color;
}