#include "..\User\User.h"

namespace AbstractRealm
{
	User::User() 
	{
	}

	User::~User()
	{

	}

	bool User::checkPress(InputStates state, unsigned int controlOption)
	{
		switch (assignedDevice)
		{
		case InputOptions::Keyboard:
			return kybrd->checkPress(state, controlOption);

		default:
			printf("Could not find device.");

			return false;
		}
	}
	
	bool User::checkHold(InputStates state, unsigned int controlOption)
	{
		switch (assignedDevice)
		{
		case InputOptions::Keyboard:
			return kybrd->checkHold(state, controlOption);

		default:
			printf("Could not find device.");

			return false;
		}
	}

	Keyboard* User::getKeyboard()
	{
		return kybrd;
	}

	void User::setKeyboard(Keyboard *passedKeyboard)
	{
		kybrd = passedKeyboard;

		assignedDevice = InputOptions::Keyboard;
	}

	void User::loadDeviceControls()
	{

	}
}