#include "AR.h"
#include "Debug.h"

namespace AbstractRealm
{
	bool Core::initialize()
	{
		printf("Attempting to initalize SDL. \n");

		if (SDL_Init(SDL_INIT_EVERYTHING) != 0)
		{
			SDL_Log("Unable to initialize SDL: %s", SDL_GetError());

			return false;
		}
		else
		{
			printf("SDL has been initialzied. \n");

			return true;
		}
	}

	void Core::setup()
	{
		printf("Setup started. \n\n");

		if (initialize())
		{
			printf("Loading Realm Managers...");
			assetMngr = AssetMngr();
			display   = Display  ();
			inputMngr = InputMngr();

			StateMngr statMngr = StateMngr();

			triangleObj = TriangleObj();
			sprite		= Sprite	 ();

			colorShader = GLSL_Core();

			setTiming();

			window = SDL_CreateWindow
			(
				"Game name"		      ,   //Window Title
				SDL_WINDOWPOS_CENTERED,   //Position X-Axis(Horizantal)
				SDL_WINDOWPOS_CENTERED,   //Position Y-Axis(Vertical  )
				display.wWidth		  ,   //Width
				display.wHeight		  ,   //Height
				SDL_WINDOW_OPENGL		  //Flags
			); if (window == nullptr) { errorHandler("SDL_CreateWindow function failed. You won't be getting a window."); }   //Just checks to see if CreateWindow() did its job.

			SDL_GLContext glContext = SDL_GL_CreateContext(window); if (glContext == nullptr) { errorHandler("SDL_GL_CreateContext failed. No graphics for you."); }   //Creates OpenGL context within window.
			GLenum		  error		= glewInit					(); if (error     != GLEW_OK) { errorHandler("Glew failed to initalize. WEW!!!"				   ); }   //Initalizes and checks glew.

			SDL_GL_SetAttribute(SDL_GL_DOUBLEBUFFER, 1);

			glClearColor(0, 0, 0, 1.0);

			sprite.initialize(0.0f, 0.0f, 1.0f, 1.0f);

			colorShader.createShaders("Shader\\colorShading.vert", "Shader\\colorShading.frag");
			colorShader.addAttribute ("vertexPosition"										  );
			colorShader.addAttribute ("vertexColor"											  );
			colorShader.linkShaders														     ();
		}
		else
			printf("Halting setup since SDL did not properly initialize. Quit now fix this thing.");
	}
}