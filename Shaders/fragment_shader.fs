#version 330 core

uniform vec4 color;
uniform int use_color;
varying vec2 out_texture;
uniform sampler2D imagem;

void main(){
    if (use_color == 1)
        gl_FragColor = color;
    else
        gl_FragColor = texture2D(imagem, out_texture);
}