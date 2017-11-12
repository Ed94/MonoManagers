#include "AR.h"

namespace AbstractRealm
{
	void Core::setTiming() { }

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
}