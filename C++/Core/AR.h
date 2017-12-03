#pragma once
#include "../Assets/Assets.h"
#include "../Control/Control.h"
#include "../Input/Input.h"
#include "../Options/Config.h"
#include "../States/StateMngr.h"
#include "../States/AR_States.h"
#include "../User/User.h"

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

		//Timing Related.
		bool checkTiming();
		void setTiming  ();
		
		void setup();

		void showCycleInfo();

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
		enum DebugLevel { critical,	warnings, info, verbose}; DebugLevel defcon;

		long double  seconds, updateInterval, renderInterval, updateCount;

		Uint64  loopCount, deltaTime, prevTime, frequency, updateRate, renderRate;

		SDL_Surface *screenSurface, *testSurface;
		SDL_Window  *window						;	
	};
}