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
		SDL_Joystick	  ** openJoysticks  ();
		SDL_GameController** openControllers();

		void closeJoysticks								 ();
		void closeJoystick (SDL_Joystick		 *joystick);
		void closeJoystick (SDL_JoyDeviceEvent jDeviceInfo);

		void closeControllers										   ();
		void closeController (SDL_GameController			 *controller);
		void closeController (SDL_ControllerDeviceEvent cDeviceEventInfo);

		unsigned char joyCount;
		unsigned char padCount;
		
		SDL_Joystick	   **joysticks  ;
		SDL_GameController **controllers;

		//AR Device Interface Level
		//Non - Dynamic
		Keyboard	   kybrd	 ;
		//Keyboard_Mouse kybrdMouse;
		//Keyboard_Joystick kybrdJoy;

		//Dynamic
		Controller	  *contrs  ;
		GC_Controller *gcContrs;
	};
};