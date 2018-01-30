#include "InputDevices.h"

namespace AbstractRealm
{
	//Public
	Joystick::Joystick(SDL_Joystick *joyRef)
	{
		this->joyRef = joyRef;
	}

	Joystick::~Joystick()
	{

	}

	void Joystick::startup()
	{
		currState.lengthAxes    = SDL_JoystickNumAxes   (joyRef);
		currState.lengthBalls   = SDL_JoystickNumBalls  (joyRef);
		currState.lengthButtons = SDL_JoystickNumButtons(joyRef);
		currState.lengthHats    = SDL_JoystickNumHats   (joyRef);

		currState.axes	  = new Uint8[currState.lengthAxes   ];
		currState.balls	  = new Uint8[currState.lengthBalls  ];
		currState.buttons = new Uint8[currState.lengthButtons];
		currState.hats    = new Uint8[currState.lengthHats   ];

		setDefaultBinds();
	}

	void Joystick::updateJoyState()
	{

	}

	bool Joystick::checkButtonPress(InputStates state, unsigned int controlOption)
	{
		return false;
	}

	bool Joystick::checkButtonHold(InputStates state, unsigned int controlOption)
	{
		return false;
	}

	//Private
	void Joystick::buttonPressInfo(SDL_Event & inputEvent)
	{
	}

	void Joystick::setDefaultBinds()
	{
		printf("\nSetting up default joystick bindings.\n");

		int numAxes = SDL_JoystickNumAxes(joyRef);

		//Axes and Balls get double the binds since it can be any 4 directions for now.
		//Technically speaking you can do a combo bind but my input system isn't there yet.
		//Or that maybe interpreted by the mechanics side from what is read from the input bind.

		menuJoy.menuBinds.setAxisBinding("Up", 0, 0, (unsigned int)MenuControls::Up, 0);
		
		/*menuJoy.menuBinds.a

		if (SDL_JoystickNumHats(joyRef) > 0)
		{
			menuJoy.menuBinds.axisBinds[1].
		}*/
	}

	void Joystick::setupBinds()
	{
	}

	Uint8 Joystick::getButtonBind(InputStates state, unsigned int controlOption)
	{
		return Uint8();
	}

}