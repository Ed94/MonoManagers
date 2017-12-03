#pragma once
#include "../Control/Control.h"
#include "../Input/InputDevices.h"
#include "../User/User.h"

#include <SDL.h >
#include <vector>

namespace AbstractRealm
{
	class InputMngr : public RealmControl
	{
	public:
		 InputMngr();
		~InputMngr();

		void checkInput		   ();
		void detectInputDevices();

		//bool checkPress(User user, InputState::Controls bind);

		//bool checkHold();

		//template<Keyboard, Keyboard_Joystick, Keyboard_Mouse>
		//bool attatchDevice(User user, Device device);

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

		//Dynamic
		Controller	  *contrs  ;
		GC_Controller *gcContrs;
	};
};