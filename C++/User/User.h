#pragma once
#include "../Input/Input.h"
#include "../Input/InputDevices.h"

namespace AbstractRealm
{
	class User
	{
	public:
		 User();
		~User();


		//Devices

		//General
		bool checkPress(InputStates state, unsigned int ControlOption);
		bool checkHold (InputStates state, unsigned int ControlOption);

		void loadBinds();

		//Keyboard
		Keyboard* getKeyboard					     ();
		void	  setKeyboard(Keyboard *passedKeyboard);

		InputOptions assignedDevice;


		//Devices
		Keyboard	      *kybrd		;
		Keyboard_Mouse	  *kybrd_mouse  ;
		Keyboard_Joystick *kybrd_joy    ;
		Joystick		  *joystick     ;
		Controller		  *controller   ;
	};
}