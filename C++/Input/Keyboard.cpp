#include "../Input/InputDevices.h"

#include <iostream>

using namespace std;

namespace AbstractRealm
{
	Keyboard::Keyboard()
	{
		//genKybrd.Cease = SDLK_END;
	}

	Keyboard::~Keyboard()
	{

	}


	void Keyboard::updateKeyState(SDL_Event &inputEvent)
	{
		keyPressInfo(inputEvent);

		prevState = currState;

		currState = SDL_GetKeyboardState(NULL);
	}

	void Keyboard::checkPress()
	{
		
	}

	void Keyboard::checkHold()
	{

	}

	void Keyboard::keyPressInfo(SDL_Event &inputEvent)
	{
		cout << "The Key Pressed was: " << inputEvent.key.keysym.sym << endl;
	}
}