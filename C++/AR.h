#pragma once
#include "Control.h"
#include "Input.h"
#include "Assets.h"
#include "Config.h"
#include "User.h"
#include "StateMngr.h"

#include "TestObjects.h"
#include "2DObjects.h"
#include "shaders.h"

#include <cstdlib>
#include <SDL.h>
#include <GL\glew.h>
#include <Windows.h>


namespace AbstractRealm
{
	class Core : public RealmControl
	{
	public:
		 Core();
		~Core();

	private:
		//Core Funcs
		bool initialize();

		void update();
		void render();

		void setTiming();
		void setup    ();

		//RealmControl Level
		AssetMngr assetMngr;
		Display     display;
		InputMngr inputMngr;

		//AR classes
		User reiningUser;

		//Temp
		TriangleObj triangleObj;
		Sprite			 sprite;
		GLSL_Core	colorShader;

		//Core Vars
		Uint64 loopCount, deltaTime, updateRate, renderRate;

		SDL_Surface *screenSurface, *testSurface;
		SDL_Window  *window						;
	};
}