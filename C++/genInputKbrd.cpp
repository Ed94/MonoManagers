#include <SDL.h>
#include <iostream>
#include "Input.h"
#include "AR.h"

namespace AbstractRealm
{
	GenInputKbrd::GenInputKbrd()
	{

	}

	GenInputKbrd::~GenInputKbrd()
	{

	}

	void GenInputKbrd::checkPress(SDL_Event &inputEvent)
	{
		switch (inputEvent.key.keysym.sym)
		{
		case SDLK_END:
			cease();
			break;
		}
	}

	void GenInputKbrd::checkHold()
	{

	}
}