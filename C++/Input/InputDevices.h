#pragma once
#include "../Input/InputStates.h"

#include <vector>
#include <SDL.h>

namespace AbstractRealm
{
	//Base Structs
	struct InputDevice
	{
		virtual void startup   ();
		virtual void checkPress();
		virtual void checkHold ();
	};

	//Keyboard Related
	class Keyboard : InputDevice
	{
	public:
		 Keyboard();
		~Keyboard();

		void startup();
		
		void updateKeyState();

		bool checkPress(InputStates state, unsigned int controlOption);
		bool checkHold (InputStates state, unsigned int controlOption);

	private:
		void keyPressInfo   (SDL_Event &inputEvent);
		void setDefaultBinds					 ();
		void setupBinds							 ();

		SDL_Keycode getBind(InputStates state, unsigned int controlOption);

		MenuState<KeyControls> menuKybrd;
		TestState<KeyControls> testKybrd;

			  int		length;   //Length of the SDL keyboard registry array.
		const Uint8 *currState;   //State of the keyboard in the current  cycle.
			  Uint8 *prevState;   //State of the keyboard in the previous cycle.
	};

	//Joystick & Pad Related
	class Joystick : InputDevice
	{
	public:
		 Joystick(SDL_Joystick *joyRef);
		~Joystick();

		void startup();

		void updateJoyState();

		bool checkButtonPress(InputStates state, unsigned int controlOption);
		bool checkButtonHold (InputStates state, unsigned int controlOption);

	private:
		void buttonPressInfo(SDL_Event &inputEvent);
		void setDefaultBinds					 ();
		void setupBinds							 ();
		
		Uint8 getButtonBind(InputStates state, unsigned int controlOption);

		MenuState<JoyControls> menuJoy;
		TestState<JoyControls> testJoy;

		JoystickState currState;
		JoystickState prevState;

		SDL_Joystick *joyRef;

		string JoyName;

		Uint8 joyIndex;
	};

	class Controller : InputDevice
	{
	public:
		 Controller();
		~Controller();

		void startup();

		void updatePadState();

		bool checkButtonPress(InputStates state, unsigned int controlOption);
		bool checkButtonHold (InputStates state, unsigned int controlOption);

	private:
		void buttonPressInfo(SDL_Event &inputEvent);
		void setDefaultBinds					 ();
		void setupBinds							 ();

		Uint8 getButtonBind(InputStates state, unsigned int controlOption);

		MenuState<ControllerControls> menuPad;
		TestState<ControllerControls> testPad;

		ControllerState currState;
		ControllerState prevState;

		string padName;

		Uint8 padIndex;
	};

	class GC_Controller : Controller { };

	//Combos
	class Keyboard_Joystick : Keyboard, Joystick { };
	class Keyboard_Mouse	: Keyboard			 { };
}