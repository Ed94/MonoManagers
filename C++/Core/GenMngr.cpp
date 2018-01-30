#include "AR.h"

namespace AbstractRealm
{
	bool Core::checkTiming()
	{
		updateInterval = ((long double)frequency / (long double)updateRate);
		renderInterval = ((long double)frequency / (long double)renderRate);

		updateCount = updateCount + updateInterval;

		if  (updateCount <= renderInterval) { return true ; }
		else                                { return false; }
	}

	void Core::setTiming()
	{ 
		//Times per second.
		updateRate = 1;
		renderRate = 1;
	}

	void Core::update()
	{
		inputMngr.checkInput();

		stateMngr.updateState();
	}

	void Core::render()
	{
		glClearDepth(1.0									  );
		glClear		(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		stateMngr.drawState();

		SDL_GL_SwapWindow(window);
	}

	void Core::showCycleInfo()
	{
		std::cout << "Loop Cycle   : " << loopCount << "\n"  ;
		std::cout << "Delta Time   : " << deltaTime << "\n"  ;
		std::cout << "Previous Time: " << prevTime  << "\n"  ;
		std::cout << "Frequency    : " << frequency << "\n"  ;
		std::cout << "Seconds      : " << seconds   << "\n\n";
	}
}