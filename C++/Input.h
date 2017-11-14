#pragma once
#include "Control.h"
#include "User.h"

#include <SDL.h>

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

		void checkInput();

		void detectInputDevices();

	private:
		SDL_Joystick** openJoysticks(const unsigned int numOfSticks);
		
		void deleteJoysticks(const unsigned int numOfSticks);

		void removeController(SDL_ControllerDeviceEvent cDeviceEventInfo);

		unsigned int joystickNum;

		User *immersedUsers;

		SDL_Joystick **joysticks;

		GenInputKbrd genInputKbrd;
	};
};