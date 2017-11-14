#include "AR.h"

namespace AbstractRealm
{
	bool Core::initialize()
	{
		printf("Attempting to initalize SDL. \n");

		if  (SDL_Init(SDL_INIT_EVERYTHING) != 0) { SDL_Log("Unable to initialize SDL: %s", SDL_GetError());  return false; }
		else									 { printf ("SDL has been initialzied. \n"				 );  return true ; }
	
		/*if (SDL_Init(SDL_INIT_TIMER != 0))
		{
			SDL_Log("Unable to initialize SDL Timer: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Timer has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_VIDEO != 0))
		{
			SDL_Log("Unable to initialize SDL Video: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Video has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_AUDIO != 0))
		{
			SDL_Log("Unable to initialize SDL Audio: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Audio has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_EVENTS != 0))
		{
			SDL_Log("Unable to initialize SDL Events: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Events has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_JOYSTICK != 0))
		{
			SDL_Log("Unable to initialize SDL Joystick: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Joystick has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_GAMECONTROLLER != 0))
		{
			SDL_Log("Unable to initialize SDL Audio: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Audio has been initialzied. \n"); }

		if (SDL_Init(SDL_INIT_HAPTIC != 0))
		{
			SDL_Log("Unable to initialize SDL Haptics: %s", SDL_GetError());  return false;
		}
		else { printf("SDL Haptics has been initialzied. \n"); }

		return true;*/
	}

	void Core::setup()
	{
		printf("Setup started. \n\n");

		if (initialize())
		{
			setTiming();

			window = SDL_CreateWindow
			(
				"Game name"			  ,   //Window Title
				SDL_WINDOWPOS_CENTERED,   //Position X-Axis(Horizantal)
				SDL_WINDOWPOS_CENTERED,   //Position Y-Axis(Vertical  )
				display.wWidth		  ,   //Width
				display.wHeight		  ,   //Height
				SDL_WINDOW_OPENGL		  //Flags
			); if (window == nullptr) { errorHandler("SDL_CreateWindow function failed. You won't be getting a window."); }   //Just checks to see if CreateWindow() did its job.

			SDL_GLContext glContext = SDL_GL_CreateContext(window); if (glContext == nullptr) { errorHandler("SDL_GL_CreateContext failed. No graphics for you."); }   //Creates OpenGL context within window.
			GLenum		  error		= glewInit			        (); if (error     != GLEW_OK) { errorHandler("Glew failed to initalize. WEW!!!"					); }   //Initalizes and checks glew.

			//OpenGL setup.
			SDL_GL_SetAttribute(SDL_GL_DOUBLEBUFFER, 1);
			glClearColor	   (0, 0, 0, 1.0		  );

			inputMngr.detectInputDevices();

			stateMngr.setCRTState(ar_states.rectTest);
		}
		else
			printf("Halting setup since SDL did not properly initialize. Quit now fix this thing.");
 	}
}