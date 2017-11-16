#pragma once
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
		void cease   ();

	private:
		//Vars
		static bool exist;
	};
}