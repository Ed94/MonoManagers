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
		void checkPress(SDL_Event &inputEvent);
		void checkHold						();
	};

	class InputMngr : public RealmControl
	{
	public:
		 InputMngr();
		~InputMngr();

		void checkInput();
	private:
		void detectInputDevices();

		User *immersedUsers;

		GenInputKbrd genInputKbrd;
	};
};