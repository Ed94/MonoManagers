#include "Input.h"
#include "stdio.h"
#include "AR.h"

#include <iostream>

using namespace std;

namespace AbstractRealm
{
	InputMngr::InputMngr()
	{
		printf("Input Manager initalized \n");

		genInputKbrd = GenInputKbrd();
	}

	InputMngr::~InputMngr() { }


	void InputMngr::checkInput()
	{
		SDL_Event inputEvent;

		while (SDL_PollEvent(&inputEvent))
		{
			switch (inputEvent.type)
			{
			case SDL_KEYDOWN:
				genInputKbrd.checkPress(inputEvent);
				break;

			//Device Handling
			case SDL_CONTROLLERDEVICEREMOVED:
				removeController(inputEvent.cdevice);
				break;
			}
		}
	}



	void InputMngr::detectInputDevices()
	{
		printf("Querying available input devices...\n");

		//Keyboard

		//Mouse

		//Joystcicks	
		if (SDL_NumJoysticks() > 0)
		{
			cout << SDL_NumJoysticks() << " joysticks  found:" << endl; //(SDL sees all non keyboard and mouse inputs as joysticks)
			cout << "Checking each joystick..." << endl;

			joysticks = openJoysticks(SDL_NumJoysticks());
		}
		else { printf("No joysticks are available.\n"); }

		//Controllers

		//Haptics (Force feedback stuff)
		if (SDL_NumHaptics() > 0) { cout << SDL_NumHaptics() << " haptics  found." << endl; } 
	}   

	SDL_Joystick** InputMngr::openJoysticks(const unsigned int numberOfSticks)
	{
		printf("Attempting to open all joysticks...\n\n");

		SDL_Joystick **joysticks = new SDL_Joystick*[numberOfSticks];

		for (unsigned int index = 0; index < SDL_NumJoysticks(); index++)
		{
			joysticks[index] = SDL_JoystickOpen(index);

			cout << "Attempting to read the joystick at index: " << index << endl;

			if (joysticks[index] != NULL)
			{
				printf("Joystick Opened\n");

				cout << "Name             : " << SDL_JoystickName			  (joysticks[index])		<< endl;
				cout << "Number of Axes   : " << SDL_JoystickNumAxes		  (joysticks[index])		<< endl;
				cout << "Number of Balls  : " << SDL_JoystickNumBalls		  (joysticks[index])		<< endl;
				cout << "Number of Buttons: " << SDL_JoystickNumButtons		  (joysticks[index])		<< endl;
				cout << "Number of Hats   : " << SDL_JoystickNumHats		  (joysticks[index])		<< endl;
				cout << "Battery Level    : " << SDL_JoystickCurrentPowerLevel(joysticks[index]) <<"\n" << endl;
			} 
			else { cout << "Could not open the joystick.\n" << endl; }
		}

		return joysticks;
	}

	void InputMngr::removeController(SDL_ControllerDeviceEvent cDeviceEventInfo)
	{

	}
}