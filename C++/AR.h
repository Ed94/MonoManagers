#pragma once
#include "Assets.h"
#include "Config.h"
#include "Control.h"
#include "Input.h"
#include "User.h"
#include "StateMngr.h"
#include "AR_States.h"

#include <cstdlib  >
#include <SDL.h    >
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

		//Brandons
		int  getsomething  ();
		void printsomething();
		void setsomething  ();

		//States Bundle
		AR_States ar_states;

		//RealmControl Level
		AssetMngr assetMngr;
		Display     display;
		InputMngr inputMngr;
		StateMngr stateMngr;

		//AR classes
		User reiningUser;

		//Core Vars
		Uint64 loopCount, deltaTime, updateRate, renderRate;

		SDL_Surface *screenSurface, *testSurface;
		SDL_Window  *window						;
	};
}