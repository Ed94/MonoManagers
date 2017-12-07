#pragma once
#include "../Input/InputStates.h"

#include <vector>
#include <SDL.h>

namespace AbstractRealm
{
	//Base Structs
	struct InputDevice
	{
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
		void keyPressInfo(SDL_Event &inputEvent);
		void setupBinds						  ();

		SDL_Keycode getBind(InputStates state, unsigned int controlOption);

		MenuState menuKybrd;
		TestState testKybrd;

			  int		length;   //Length of the SDL keyboard registry array.
			  Uint8 *prevState;   //State of the keyboard in the previous cycle.
		const Uint8 *currState;   //State of the keyboard in the current  cycle.
	};

	class Keyboard_Joystick : Keyboard
	{
	public:
		 Keyboard_Joystick();
		~Keyboard_Joystick();

		void checkPress();
		void checkHold ();
	private:
		MenuState menuKybrdJoy;
	};

	class Keyboard_Mouse : Keyboard
	{
	public:
		 Keyboard_Mouse();
		~Keyboard_Mouse();

		void checkPress();
		void checkHold ();
	private:
		MenuState menuKybrdMouse;
	};

	class Joystick : InputDevice
	{

	};

	//Joystick & Pad Related
	class Controller : InputDevice
	{
	public:
		 Controller();
		~Controller();

		void checkPress();
		void checkHold ();
	private:
		MenuState menuController;
	};


	class GC_Controller : Controller
	{
	public:
		 GC_Controller();
		~GC_Controller();

		void checkPress();
		void checkHold ();
	private:
		MenuState menuControllerGC;
	};
}