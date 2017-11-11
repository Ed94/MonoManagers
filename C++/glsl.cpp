#include "shaders.h"
#include "Debug.h"

namespace AbstractRealm
{
	GLSL_Core:: GLSL_Core() : attributeCount(0), realmShaderID(0), vertShaderID(0), fragShaderID(0) {}
	GLSL_Core::~GLSL_Core()																			{}

	//GLuint GLSL_Core::getUniformLocation(const std::string& uniformName)
	//{ return glGetUniformLocation(realmShaderID, uniformName.c_str); }

	void GLSL_Core::add()
	{ 
		glUseProgram(realmShaderID); 

		for (unsigned int index = 0; index < attributeCount; index++)
			glEnableVertexAttribArray(0);
	}

	void GLSL_Core::addAttribute(const std::string &attributeName)
	{
		glBindAttribLocation(realmShaderID, attributeCount++, attributeName.c_str());
	}

	void GLSL_Core::createShaders(const std::string vertShaderPath, const std::string fragShaderPath)
	{
		realmShaderID = glCreateProgram();

		vertShaderID = glCreateShader(GL_VERTEX_SHADER  ); if (vertShaderID == 0) { errorHandler("Vertex shader was not created. We need dat eyecandy."); }
		fragShaderID = glCreateShader(GL_FRAGMENT_SHADER); if (fragShaderID == 0) { errorHandler("Frag   shader was not created. We need dat eyecandy."); }

		compileShader(vertShaderPath, vertShaderID);
		compileShader(fragShaderPath, fragShaderID);
	}

	void GLSL_Core::linkShaders()
	{
		glAttachShader(realmShaderID, vertShaderID); 
		glAttachShader(realmShaderID, fragShaderID);

		glLinkProgram(realmShaderID);

		GLuint isLinked = 0; glGetProgramiv(realmShaderID, GL_LINK_STATUS, (int *)&isLinked);

		if (isLinked == GL_FALSE)
		{
				 GLint			maxLength = 0     ; glGetProgramiv	   (realmShaderID, GL_INFO_LOG_LENGTH, &maxLength			  );
			std::vector<GLchar> infoLog(maxLength); glGetProgramInfoLog(realmShaderID, maxLength		 , &maxLength, &infoLog[0]);

			glDeleteProgram(realmShaderID);
			glDeleteShader (vertShaderID );
			glDeleteShader (fragShaderID );

			std::printf("%s\n", &(infoLog[0])); errorHandler("Shaders failed to link... =("); return;
		}

		glDetachShader(realmShaderID, vertShaderID); 
		glDetachShader(realmShaderID, fragShaderID);
	}

	void GLSL_Core::compileShader(std::string shaderPath, GLuint &shaderID)
	{
		std::ifstream shaderFile(shaderPath); if (shaderFile.fail()) { errorHandler("Could not open: " + shaderPath); }

		std::string fileContent = "", line = ""; while (std::getline(shaderFile, line))
													fileContent += line + "\n";

		shaderFile.close();

		const char* contentsPtr = fileContent.c_str();   //Hack for glShaderSource pointing to fileContnetString...

		glShaderSource (shaderID, 1, &contentsPtr, nullptr);
		glCompileShader(shaderID						  );

		GLint compileStatus = 0; glGetShaderiv(shaderID, GL_COMPILE_STATUS, &compileStatus);

		if (compileStatus == GL_FALSE)
		{
			      GLint		  maxLength = 0		; glGetShaderiv     (shaderID, GL_INFO_LOG_LENGTH, &maxLength			  );
			std::vector<char> infoLog(maxLength); glGetShaderInfoLog(shaderID, maxLength         , &maxLength, &infoLog[0]);
												  glDeleteShader	(shaderID											  );

			std::printf("%s\n", &(infoLog[0])); errorHandler("Shader: "+ shaderPath+ " did not compile... =("); return;
		}
	}

	void GLSL_Core::remove()
	{ 
		glUseProgram(0);

		for (unsigned int index = 0; index < attributeCount; index++)
			glDisableVertexAttribArray(index);
	}
}