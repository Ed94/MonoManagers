#version 130

in vec4 fragColor;

out vec4 color;

uniform float time;

void main()
{
	color = fragColor;
}