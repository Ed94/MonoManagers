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

		//Axes and Balls get double the binds since it can be any 4 directions for now.
		//Technically speaking you can do a combo bind but my input system isn't there yet.
		//Or that maybe interpreted by the mechanics side from what is read from the input bind.
		menuJoy.menuBinds.axisBinds   = new JoyAxisBind  [SDL_JoystickNumAxes   (joyRef)* 2];
		menuJoy.menuBinds.ballBinds   = new JoyBallBind  [SDL_JoystickNumBalls  (joyRef)* 2];
		menuJoy.menuBinds.buttonBinds = new JoyButtonBind[SDL_JoystickNumButtons(joyRef)   ];
		menuJoy.menuBinds.hatBinds	  = new JoyHatBind	 [SDL_JoystickNumHats   (joyRef)*17];

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