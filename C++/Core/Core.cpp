#include "AR.h"

#include <iostream>

namespace AbstractRealm 
{
	Core::Core()
	{
		printf("\nAR Core started. \n");

		setup();

		while (getExist())
		{
			frequency = SDL_GetPerformanceFrequency();
			deltaTime = SDL_GetPerformanceCounter  ();

			seconds = (long double)(deltaTime - prevTime) / frequency;

			std::cout << "Loop Cycle   : " << loopCount << "\n";
			std::cout << "Delta Time   : " << deltaTime << "\n"  ;
			std::cout << "Previous Time: " << prevTime  << "\n"  ;
			std::cout << "Frequency    : " << frequency << "\n"  ;
			std::cout << "Seconds      : " << seconds   << "\n\n";

			while (checkTiming()) 
			{ 
				update(); 
			}

			updateCount = 0;

			//update();
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