#include "AbstractRealm\User\UserMngr.h"

namespace AbstractRealm
{
	bool UserMngr::checkPress(AccessLevel level, InputStates state, unsigned int controlOption)
	{
		switch (level)
		{
		case AccessLevel::Any:
			for (unsigned int userIndex = 0; userIndex < userCount; userIndex++)
			{
				if (users[userIndex].checkPress(state, controlOption))
				{
					return true;
				}
			}
			break;

		case AccessLevel::Host:
			if (reiningUser->checkPress(state, controlOption))
			{
				return true;
			}
			break;
		}

		return false;
	}

	void UserMngr::setReiningUser(User *user)
	{
		reiningUser = user;
	}
}