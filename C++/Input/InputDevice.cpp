#include "..\Input\InputDevices.h"
#include "..\Input\InputStates.h"

#include <iostream>

namespace AbstractRealm
{
	void InputDevice::startup()
	{
		std::cout << "Input Device Started Called. The device has called for its startup function. For some reason its using the virtual function." << std::endl;
	}

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
}