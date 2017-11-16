#include "Input.h"

#include "../Core/AR.h"

#include <iostream>
#include <SDL.h   >

namespace AbstractRealm
{
	GenInputKbrd:: GenInputKbrd() { }
	GenInputKbrd::~GenInputKbrd() { }

	void GenInputKbrd::checkPress(SDL_Event &inputEvent)
	{
		switch (inputEvent.key.keysym.sym)
		{
		case SDLK_END:
			cease();
			break;
		}
	}

	void GenInputKbrd::checkHold() { }
}