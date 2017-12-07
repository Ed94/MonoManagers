#include "..\Input\InputDevices.h"
#include "..\Input\InputStates.h"

#include <iostream>

namespace AbstractRealm
{
	void InputDevice::checkPress()
	{
		std::cout << "Input Event occured. The device input manager has called for a 'checkPress' is using the virtual function." << std::endl;

		/*std::cout << "Input Event Type	   : " << inputEvent.common.type      << std::endl;
		std::cout << "Input Event Timestamp: " << inputEvent.common.timestamp << std::endl;*/
	}

	void InputDevice::checkHold()
	{
		std::cout << "Input Event occured. The device input manager has called for a 'checkHold' is using the virtual function." << std::endl;
	}

	SDL_Keycode InputState::getBind(unsigned int controlOption)
	{
		std::cout << "Get bind requested from an input state. However input state is using the default function. Returning zero as the bind." << std::endl;

		return 0;
	}

	void InputState::getControlsFromUser()
	{

	}
}