#include "AR.h"

#include <iostream>

namespace AbstractRealm 
{
	Core::Core()
	{
		defcon = info;

		printf("\nAR Core started. \n");

		setup();

		while (getExist())
		{
			frequency = SDL_GetPerformanceFrequency();
			deltaTime = SDL_GetPerformanceCounter  ();

			seconds = (long double)(deltaTime - prevTime) / frequency;

			if (defcon == verbose) { showCycleInfo(); }

			while (checkTiming()) { update(); } updateCount = 0;

			render();

			prevTime = deltaTime; loopCount++;
		}
	}

	Core::~Core()
	{
		SDL_QUIT;

		exit(69);
	}
}