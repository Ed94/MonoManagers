#pragma once

#include <vector>
#include <SDL.h>

namespace AbstractRealm
{
	struct InputState
	{
	public:
		enum class Controls;

		void getControlsFromUser();
	};

	//Base Structs
	struct InputDevice
	{
		virtual void checkPress();

		virtual void checkHold ();
	};

	//States
	struct GenState : InputState
	{
	public:
		enum class Controls
		{
			Cease,
		};

		SDL_Keycode Cease;
	};

	struct TestState :InputState
	{
	public:

	};

	//Keyboard Related
	class Keyboard : InputDevice
	{
	public:
		 Keyboard();
		~Keyboard();
		
		void updateKeyState(SDL_Event &inputEvent);

		void checkPress();
		void checkHold ();
	private:
		void keyPressInfo(SDL_Event &inputEvent);

		GenState  genKybrd ;
		TestState testKybrd;

		const Uint8* prevState;   //State of the keyboard in the previous cycle.
		const Uint8* currState;   //State of the keyboard in the current  cycle.
	};

	class Keyboard_Joystick : Keyboard
	{
	public:
		 Keyboard_Joystick();
		~Keyboard_Joystick();

		void checkPress();
		void checkHold						();
	private:
		GenState genKybrdJoy;
	};

	class Keyboard_Mouse : Keyboard
	{
	public:
		 Keyboard_Mouse();
		~Keyboard_Mouse();

		void checkPress();
		void checkHold						();
	private:
		GenState genKybrdMouse;
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
		void checkHold						();
	private:
		GenState genController;
	};


	class GC_Controller : Controller
	{
	public:
		 GC_Controller();
		~GC_Controller();

		void checkPress();
		void checkHold						();
	private:
		GenState genControllerGC;
	};
}