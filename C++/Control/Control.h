#pragma once
#include "../Input/Input.h"
#include "../User/UserMngr.h"

#include <iostream>
#include <string  >


namespace AbstractRealm
{
	class RealmControl
	{
	public:
		 RealmControl();
		~RealmControl();

		//Core Loop Related
		virtual void update();
		virtual void render();

		//Debug Related
		void errorHandler(std::string errorMsg);

		//Existance Handling
		bool getExist();
		void cease();

	protected:
		static InputMngr *inputMngrPtr;
		static UserMngr  *userMngrPtr ;

	private:
		//Vars
		static bool exist;
	};
}