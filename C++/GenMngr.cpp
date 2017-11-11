#include "AR.h"

namespace AbstractRealm
{
	void Core::render()
	{
		glClearDepth(									   1.0);
		glClear		(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		colorShader.add();
		
		//triangleObj.renderTriangle();

		sprite.render();

		colorShader.remove();

		SDL_GL_SwapWindow(window);

		//stateMngr.drawStates();
	}

	void Core::setTiming()
	{

	}

	void Core::update()
	{
		//stateMngr.updateStates();

		inputMngr.checkInput();
	}
}