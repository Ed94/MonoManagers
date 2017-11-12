#include "AR.h"

namespace AbstractRealm 
{
	Core::Core()
	{
		printf("\nAR Core started. \n");

		setup();

		while (getExist())
		{
			deltaTime = SDL_GetPerformanceCounter();

			update();
			render();

			loopCount++;
		}
	}

	Core::~Core()
	{
		SDL_QUIT;

		exit(69);
	}
}