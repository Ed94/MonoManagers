#pragma once
#include "../Control/Control.h"
#include "../User/User.h"

#include <SDL.h >
#include <vector>

namespace AbstractRealm
{
	class GenInputKbrd : private RealmControl
	{
	public:
		 GenInputKbrd();
		~GenInputKbrd();

		void checkPress(SDL_Event &inputEvent);
		void checkHold						();

	private:
		enum Controls
		{
			Cease
		};
	};

	struct InputState { };

	struct InputDevice
	{
		virtual void checkPress(SDL_Event &inputEvent);
		virtual void checkHold						();
	};

	class InputMngr : public RealmControl
	{
	public:
		 InputMngr();
		~InputMngr();

		void checkInput		   ();
		void detectInputDevices();

	private:
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

		SDL_Joystick		 **joysticks;
		SDL_GameController **controllers;

		GenInputKbrd genInputKbrd;

		User *immersedUsers;
	};
};