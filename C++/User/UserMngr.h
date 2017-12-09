#pragma once
#include "User.h"

namespace AbstractRealm
{
	enum class AccessLevel
	{
		Host,
		Any
	};

	class UserMngr
	{
	public:
		 UserMngr();
		~UserMngr();

		bool checkPress(AccessLevel level, InputStates state, unsigned int controlOption);

		bool loadUsers();

		void poplulateUsers();

		void setReiningUser(User *user);

	private:
		User *reiningUser;  //The host user.
		User *users      ;   //Other users (Ex: player 2, player 3, etc.)

		unsigned int userCount;
	};
}