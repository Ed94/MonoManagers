#include "Input.h"
#include "stdio.h"
#include "AR.h"

namespace AbstractRealm
{
	InputMngr::InputMngr()
	{
		printf("Input Manager initalized \n");

		detectInputDevices();

		genInputKbrd = GenInputKbrd();
	}

	InputMngr::~InputMngr()
	{

	}

	void InputMngr::checkInput()
	{
		SDL_Event inputEvent;

		while (SDL_PollEvent(&inputEvent))
		{
			switch (inputEvent.type)
			{
			case SDL_KEYDOWN:
				genInputKbrd.checkPress(inputEvent);
				break;
			}
		}
	}

	void InputMngr::detectInputDevices()
	{

	}
}