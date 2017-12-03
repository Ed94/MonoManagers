#include "AbstractRealm\Input\InputDevices.h"

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

	void InputState::getControlsFromUser()
	{
		std::cout << "An input state's function for getting controls from a user persona was called. Virtual function was used." << std::endl;
	}
}