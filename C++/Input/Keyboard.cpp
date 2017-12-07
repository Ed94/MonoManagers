#include "../Input/InputDevices.h"

#include <iostream>
#include <cstring>

using namespace std;

namespace AbstractRealm
{
	Keyboard::Keyboard()
	{
		prevState = new Uint8[length];
	}

	Keyboard::~Keyboard()
	{

	}

	void Keyboard::startup()
	{
		setupBinds();

		currState = SDL_GetKeyboardState(&length);

		std::memcpy(prevState, currState, length);
	}

	void Keyboard::setupBinds()
	{
		printf("Setting up keyboard bindings.\n");

		menuKybrd.Cease =  SDLK_END		;
		menuKybrd.Select = SDLK_KP_ENTER;
	}

	void Keyboard::updateKeyState()
	{
		std::memcpy(prevState, currState, length);
	}

	bool Keyboard::checkPress(InputStates state, unsigned int controlOption)
	{
		SDL_Keycode  key  = getBind		          (state, controlOption);
		SDL_Scancode code = SDL_GetScancodeFromKey(key				   );

		if  (currState[code] && !prevState[code]){ return true ; }
		else									 { return false; }
	}

	bool Keyboard::checkHold(InputStates state, unsigned int controlOption)
	{
		SDL_Keycode  key  = getBind			      (state, controlOption);
		SDL_Scancode code = SDL_GetScancodeFromKey(key				   );

		if  (currState[code] && prevState[code]) { return true ; }
		else									 { return false; }
	}

	SDL_Keycode Keyboard::getBind(InputStates inputState, unsigned int controlOption)
	{
		switch (inputState)
		{
		case InputStates::Menu:
			return menuKybrd.getBind(controlOption);
			break;
		case InputStates::Test:
			return testKybrd.getBind(controlOption);
			break;

		default:
			return 0;
			break;
		}
	}

	void Keyboard::keyPressInfo(SDL_Event &inputEvent)
	{
		cout << "The Key Pressed was: " << inputEvent.key.keysym.sym << endl;
	}
}