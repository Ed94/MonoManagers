#pragma once

#include <SDL.h>

namespace AbstractRealm   //Determining InputState should be more modular.
{						 //It would be better if inputStates store an array of inputStates with the length of states stored in a sturct?
	//General
	enum class InputOptions
	{
		Keyboard      ,
		Keyboard_Mouse,
		Keyboard_Joy  ,
		Joystick      ,
		Controller    ,
	};

	enum class InputStates
	{
		Menu,
		Test,
	};

	struct ControlBind
	{
		unsigned int		 EnumIndex;
		         SDL_Keycode bind	  ;
	};

	struct InputState
	{
	public:
		enum class Controls;

		SDL_Keycode getBind(unsigned int controlOption);

		void getControlsFromUser();
	};


	//States

	//Menu
	enum class MenuControls
	{
		Cease	 ,
		Select	 ,
		Back	 ,
		Up		 ,
		Down     ,
		Left     ,
		Right    ,
		ENUM_SIZE,
	};

	struct MenuState : InputState
	{
	public:
		SDL_Keycode getBind(unsigned int controlOption);

		//ControlBind Cease;

		SDL_Keycode Cease ;
		SDL_Keycode Select;
		SDL_Keycode Back  ;
		SDL_Keycode Up    ;
		SDL_Keycode Down  ;
		SDL_Keycode Left  ;
		SDL_Keycode Right ;
	};

	//Test
	enum class TestControls
	{
		Pause      ,
		OpenMenu   ,
		debugToggle,
	};

	struct TestState :InputState
	{
	public:

	};
}