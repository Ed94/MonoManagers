#pragma once

#include <iostream>
#include <string>
#include <SDL.h>

using namespace std;

namespace AbstractRealm   //Determining InputState should be more modular.
{						  //It would be better if inputStates store an array of inputStates with the length of states stored in a sturct?
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

	struct DeviceBindData
	{
		unsigned int    EnumIndex;
				 string name     ;
	};

	struct DeviceControlData
	{
		unsigned int length;
	};

	//keyboard
	struct KeyControlBind : DeviceBindData { SDL_Keycode bind; };

	struct KeyControls : DeviceControlData 
	{
		void setBind(std::string name, SDL_Keycode bind, unsigned int bindName);

		KeyControlBind *binds;  
	};

	//Mouse
	struct MouseButtonBind { };   //Not Implemented
	struct MouseCursorBind { };   //Not Implemented

	//Joystick
	struct JoystickState
	{
		//Axes
		Uint8  lengthAxes;
		Uint8 *axes		 ;

		//Balls
		Uint8  lengthBalls;
		Uint8 *balls;

		//Buttons
		Uint8  lengthButtons;
		Uint8 *buttons;

		//Hats
		Uint8  lengthHats;
		Uint8 *hats;
	};

	struct JoyAxisBind   : DeviceBindData { unsigned int axis  ; };
	struct JoyBallBind   : DeviceBindData { unsigned int ball  ; };
	struct JoyButtonBind : DeviceBindData { unsigned int button; };
	struct JoyHatBind    : DeviceBindData { unsigned int hat   ; };

	struct JoyControls : DeviceControlData
	{
		enum JoyInputType { axis, ball, button, hat };

		template<typename JoyInput>
		void setBinding(JoyInputType type, string name, JoyInput input, unsigned int bindName);

		JoyAxisBind   *axisBinds  ;
		JoyBallBind   *ballBinds  ;
		JoyButtonBind *buttonBinds;
		JoyHatBind    *hatBinds   ;
	};

	//Controllers
	struct ControllerState
	{
		//Axes
		Uint8  lengthAxes;
		Uint8 *axes		 ;

		//Buttons
		Uint8  lengthButtons;
		Uint8 *Buttons		;
	};

	struct ControllerAxisBind   : DeviceBindData { SDL_GameControllerAxis   axis  ; };
	struct ControllerButtonBind : DeviceBindData { SDL_GameControllerButton button; };

	struct ControllerControls : DeviceControlData
	{
		ControllerAxisBind   *axisBinds  ;
		ControllerButtonBind *buttonBinds;
	};

	//Combos
	struct Key_MouseControls : DeviceControlData { };   //Not implemented

	struct Key_JoyControls : DeviceControlData
	{
		KeyControlBind *keyBinds   ;
		JoyAxisBind    *axisBinds  ;
		JoyBallBind    *ballBinds  ;
		JoyButtonBind  *buttonBinds;
		JoyHatBind     *hatBinds   ;
	};


	//States
	struct InputState
	{
	public:
		//SDL_Keycode getBind(unsigned int controlOption);
	};

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

	template<typename controlType> 
	class MenuState: InputState
	{
	public:
		controlType menuBinds;
	};

	//Test
	enum class TestControls
	{
		Pause      ,
		OpenMenu   ,
		debugToggle,
		ENUM_SIZE  ,
	};

	template<typename controlType>
	struct TestState : InputState
	{
	public:
		controlType testBinds;
	};
}