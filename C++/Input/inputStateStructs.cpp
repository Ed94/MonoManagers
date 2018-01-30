#include "InputStates.h"

namespace AbstractRealm
{
	void KeyControls::setBind(std::string name, SDL_Keycode bind, unsigned int bindIndex)
	{
		this->binds[bindIndex].name      = name     ;
		this->binds[bindIndex].EnumIndex = bindIndex;
		this->binds[bindIndex].bind      = bind		;
	}

	void JoyControls::setAxisBinding(std::string bindName, Uint8 orientation,  int direction, Uint8 axisNum, unsigned int bindIndex)
	{
		this->axes[axisNum].axisBinds[bindIndex].name	   = bindName   ;
		this->axes[axisNum].axisBinds[bindIndex].direction = direction  ;
		this->axes[axisNum].axisBinds[bindIndex].EnumIndex = bindIndex  ;
		this->axes[axisNum].axisBinds[bindIndex].axis	   = orientation;
	}
}