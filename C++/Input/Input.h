#pragma once
#include "../Input/InputDevices.h"
#include "../Input/InputStates.h"

#include <SDL.h >
#include <vector>

namespace AbstractRealm
{
	class InputMngr
	{
	public:
		 InputMngr();
		~InputMngr();

		void checkInput		   ();
		void detectInputDevices();

		Keyboard *getKeyboard();

	private:
		//Device Related

		//Joysticks
		SDL_Joystick** openJoys									  ();
		void		   openJoystick(SDL_Joystick       *joystick   );
		void		   openJoystick(SDL_JoyDeviceEvent  jDeviceInfo);

		void closeJoysticks								 ();
		void closeJoystick (SDL_Joystick		 *joystick);
		void closeJoystick (SDL_JoyDeviceEvent jDeviceInfo);

		//Controllers
		SDL_GameController** openPads											 ();
		void				 openController(SDL_GameController        *controller );
		void				 openController(SDL_ControllerDeviceEvent  cDeviceInfo);

		void closeControllers									   ();
		void closeController (SDL_GameController	    *controller );
		void closeController (SDL_ControllerDeviceEvent  cDeviceInfo);

		Uint8 SDL_JoyCount;
		Uint8 SDL_PadCount;
		
		SDL_Joystick	   **joysticks  ;
		SDL_GameController **controllers;

		//AR Device Interface Level

		//Non - Dynamic
		Keyboard kybrd;
		//Keyboard_Mouse kybrdMouse;
		//Keyboard_Joystick kybrdJoy;

		//Dynamic
		void updateJoyState();
		void updatePadState();

		Uint8 joyCount  ;
		Uint8 padCount  ;
		Uint8 gcPadCount;

		Joystick	  *joys  ;
		Controller	  *pads  ;
		GC_Controller *gcPads;
	};
};