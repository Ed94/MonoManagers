#include "AbstractRealm\Input\InputStates.h"

namespace AbstractRealm
{
	SDL_Keycode MenuState::getBind(unsigned int controlOption)
	{
		     if (controlOption == (unsigned int)MenuControls::Cease ) { return Cease ; }
		else if (controlOption == (unsigned int)MenuControls::Select) { return Select; }
		else if (controlOption == (unsigned int)MenuControls::Back  ) { return Back  ; }
		else if (controlOption == (unsigned int)MenuControls::Up    ) { return Up    ; }
		else if (controlOption == (unsigned int)MenuControls::Down  ) { return Down  ; }
		else if (controlOption == (unsigned int)MenuControls::Left  ) { return Left  ; }
		else if (controlOption == (unsigned int)MenuControls::Right ) { return Right ; }
		else														  { return		0; }

		/*for (unsigned int enumIndex = 0; enumIndex < (unsigned int)MenuControls::ENUM_SIZE; enumIndex++)
		{
			if (controlOption == enumIndex) { return getControlBind(enumIndex); }
		}*/
	}
}