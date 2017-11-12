#pragma once
#include "Input.h"

#include <SDL.h>

namespace AbstractRealm
{
	class Keyboard : InputDevice
	{
	public:
		struct general : InputState
		{
		private:
			enum Controls
			{
				Cease
			};
		};

		void checkPress(SDL_Event &inputEvent);
		void checkHold						();
	};
}