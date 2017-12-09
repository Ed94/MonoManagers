#include "../Input/InputDevices.h"

#include <iostream>
#include <cstring>

using namespace std;

namespace AbstractRealm
{
	//Public
	Keyboard::Keyboard()
	{
		prevState = new Uint8[length];
	}

	Keyboard::~Keyboard()
	{

	}

	void Keyboard::startup()
	{
		setDefaultBinds();

		currState = SDL_GetKeyboardState(&length);

		std::memcpy(prevState, currState, length);
	}

	void Keyboard::setDefaultBinds()
	{
		printf("\nSetting up default keyboard bindings.\n");

		menuKybrd.menuBinds.length = (unsigned int)MenuControls::ENUM_SIZE;

		menuKybrd.menuBinds.binds = new KeyControlBind[menuKybrd.menuBinds.length];

		menuKybrd.menuBinds.setBind("Cease"  , SDLK_END		 , (unsigned int)MenuControls::Cease );
		menuKybrd.menuBinds.setBind("Select" , SDLK_RETURN	 , (unsigned int)MenuControls::Select);
		menuKybrd.menuBinds.setBind("Back"   , SDLK_BACKSPACE, (unsigned int)MenuControls::Back	 );
		menuKybrd.menuBinds.setBind("Up"	 , SDLK_w		 , (unsigned int)MenuControls::Up	 );
		menuKybrd.menuBinds.setBind("Down"	 , SDLK_s		 , (unsigned int)MenuControls::Down  );
		menuKybrd.menuBinds.setBind("Left"	 , SDLK_a		 , (unsigned int)MenuControls::Left  );
		menuKybrd.menuBinds.setBind("Right"	 , SDLK_d		 , (unsigned int)MenuControls::Right );

		testKybrd.testBinds.length = (unsigned int)TestControls::ENUM_SIZE;

		testKybrd.testBinds.binds = new KeyControlBind[menuKybrd.menuBinds.length];

		testKybrd.testBinds.setBind("Pause"       , SDLK_ESCAPE, (unsigned int)TestControls::Pause      );
		testKybrd.testBinds.setBind("Open Menu"   , SDLK_m	   , (unsigned int)TestControls::OpenMenu   );
		testKybrd.testBinds.setBind("Debug Toggle", SDLK_F1	   , (unsigned int)TestControls::debugToggle);
	}

	void Keyboard::setupBinds()
	{
		
	}

	void Keyboard::updateKeyState()
	{
		std::memcpy(prevState, currState, length);
	}

	bool Keyboard::checkPress(InputStates state, unsigned int controlOption)
	{
		SDL_Keycode  key  = getBind		          (state, controlOption);
		SDL_Scancode code = SDL_GetScancodeFromKey(key				   );

		if  (currState[code] &&
			!prevState[code]){ return true ; }
		else									 { return false; }
	}

	bool Keyboard::checkHold(InputStates state, unsigned int controlOption)
	{
		SDL_Keycode  key  = getBind			      (state, controlOption);
		SDL_Scancode code = SDL_GetScancodeFromKey(key				   );

		if  (currState[code] && prevState[code]) { return true ; }
		else									 { return false; }
	}


	//Private
	SDL_Keycode Keyboard::getBind(InputStates inputState, unsigned int controlOption)
	{
		switch (inputState)
		{
		case InputStates::Menu:
			return menuKybrd.menuBinds.binds[controlOption].bind;
			break;
		case InputStates::Test:
			return testKybrd.testBinds.binds[controlOption].bind;
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