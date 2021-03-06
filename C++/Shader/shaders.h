#pragma once
#include "../Control/Control.h"

#include <fstream  >
#include <GL\glew.h>
#include <string   >
#include <vector   >

namespace AbstractRealm
{
	class GLSL_Core : public RealmControl
	{
	public:
		 GLSL_Core();
		~GLSL_Core();

		//GLuint getUniformLocation(const std::string& uniformName);

		void add																			();
		void addAttribute (const std::string &attributeName									 );
		void createShaders(const std::string vertShaderPath, const std::string fragShaderPath);
		void linkShaders																	();
		void remove																			();

	private:
		unsigned int attributeCount;

		GLuint realmShaderID, vertShaderID, fragShaderID;

		void compileShader(std::string shaderPath , GLuint &shaderID);
	};
}