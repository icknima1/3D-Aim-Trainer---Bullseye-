#version 300 es
precision highp float;

in vec2 vTexCoord;
out vec4 fragColor;

uniform sampler2D uTexture;

void main() {
    vec4 color = texture(uTexture, vTexCoord);
    fragColor = color;
}