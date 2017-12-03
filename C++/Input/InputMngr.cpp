#include "Input.h"
#include "stdio.h"

#include "../Core/AR.h"

#include <iostream>

using namespace std;

namespace AbstractRealm
{
	//Public
	InputMngr::InputMngr()
	{
		printf("Input Manager initalized \n");
	}

	InputMngr::~InputMngr() { }

	void InputMngr::checkInput()
	{
		SDL_Event inputEvent;

		while (SDL_PollEvent(&inputEvent))
		{
			switch (inputEvent.type)
			{
				//Input Polling
			case SDL_KEYUP || SDL_KEYDOWN:
				kybrd.updateKeyState(inputEvent);
				break;

			case SDL_JOYBUTTONUP:
				break;

			case SDL_JOYBUTTONDOWN:
				break;

				//Device Handling
			case SDL_JOYDEVICEADDED:
				break;

			case SDL_JOYDEVICEREMOVED:
				//closeJoystick(inputEvent.jdevice);
				break;

			case SDL_CONTROLLERDEVICEADDED:
				break;

			case SDL_CONTROLLERDEVICEREMOVED:
				//closeController(inputEvent.cdevice);
				break;
			}
		}
	}

	void InputMngr::detectInputDevices()
	{
		//Keyboard and Mouse are assumed to always be on.
		printf("Querying available input devices...\n");

		joyCount = SDL_NumJoysticks();

		//Joystcicks	
		if (joyCount > 0)
		{
			cout << joyCount << " joysticks  found:" << endl; //(SDL sees all non keyboard and mouse inputs as joysticks)
			cout << "Checking each joystick..." << endl;

			joysticks = openJoysticks();
		}
		else { printf("No joysticks are available.\n"); }

		//Controllers
		if (joysticks != nullptr)
		{
			controllers = openControllers();
		}
		else { printf("No joysticks to check for controller interface compatabilty.\n"); }

		//Haptics (Force feedback stuff)
		if (SDL_NumHaptics() > 0) { cout << SDL_NumHaptics() << " haptics  found." << endl; }
	}

	
	//bool InputMngr::checkPress(User user, InputState::Controls bind)
	//{
	//	/*if (user.inputDevice->checkPress(bind))
	//		true;*/
	//}

	/*template<Keyboard, Keyboard_Joystick, Keyboard_Mouse> bool InputMngr::attatchDevice(User user, Device device)
	{
		user.setInputDevice(&device);

		return true;
	}*/


	//Private

	//Device Related
	SDL_Joystick** InputMngr::openJoysticks()
	{
		printf("Attempting to open all joysticks...\n\n");

		SDL_Joystick **joysticks = new SDL_Joystick*[joyCount];

		for (unsigned int joyIndex = 0; joyIndex < joyCount; joyIndex++)
		{
			joysticks[joyIndex] = SDL_JoystickOpen(joyIndex);

			cout << "Attempting to read the joystick at index: " << joyIndex << endl;

			if (joysticks[joyIndex] != NULL)
			{
				printf("Joystick Opened\n");

				cout << "Name             : " << SDL_JoystickName			  (joysticks[joyIndex])		   << endl;
				cout << "Number of Axes   : " << SDL_JoystickNumAxes		  (joysticks[joyIndex])		   << endl;
				cout << "Number of Balls  : " << SDL_JoystickNumBalls		  (joysticks[joyIndex])		   << endl;
				cout << "Number of Buttons: " << SDL_JoystickNumButtons		  (joysticks[joyIndex])		   << endl;
				cout << "Number of Hats   : " << SDL_JoystickNumHats		  (joysticks[joyIndex])		   << endl;
				cout << "Battery Level    : " << SDL_JoystickCurrentPowerLevel(joysticks[joyIndex]) <<"\n" << endl;
			} 
			else { cout << "Could not open the joystick =/.\n" << endl; }
		}

		return joysticks;
	}

	SDL_GameController** InputMngr::openControllers()
	{
		printf("Checking Joystick compatability with game controller mappings...\n");

		SDL_GameController **padList = new SDL_GameController*[joyCount];

		for (unsigned int joyIndex = 0; joyIndex < joyCount; joyIndex++)
		{
			if (SDL_IsGameController(joyIndex))
			{
				cout << joysticks[joyIndex] << " has support for controller interface." << endl;

				cout << "Setting up device for use as controller...";

				closeJoystick(joysticks[joyIndex]);

				padList[joyIndex] = SDL_GameControllerOpen(joyIndex);

				cout << "Attempting to read the controller at index: " << joyIndex << endl;

				if (padList[joyIndex] != NULL)
				{
					printf("Controller Opened\n");

					cout << "Name             : " << SDL_GameControllerName		  (padList[joyIndex]) << endl;
					cout << "Attached?        : " << SDL_GameControllerGetAttached(padList[joyIndex]) << endl;
					cout << "Mapping		  : " << SDL_GameControllerMapping	  (padList[joyIndex]) << endl;
					
				}
				else { cout << "Could not open the controller =/.\n" << endl; }

				padCount++;
			}
		}

		return padList;
	}

	void InputMngr::closeJoystick(SDL_Joystick *joystick)
	{ SDL_JoystickClose(joystick); }

	void InputMngr::closeJoystick(SDL_JoyDeviceEvent jDeviceInfo)
	{ SDL_JoystickClose(joysticks[jDeviceInfo.which]); }

	void InputMngr::closeJoysticks()
	{
		for (unsigned char joyIndex = 0; joyIndex < joyCount; joyIndex++)
			SDL_JoystickClose(joysticks[joyIndex]);
	}

	void InputMngr::closeController(SDL_GameController *controller)
	{ SDL_GameControllerClose(controller); }

	void InputMngr::closeController(SDL_ControllerDeviceEvent cDeviceEventInfo)
	{ SDL_GameControllerClose(controllers[cDeviceEventInfo.which]); }

	void InputMngr::closeControllers() {}
}