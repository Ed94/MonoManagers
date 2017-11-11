#pragma once
#include "Control.h"
#include "AR_StateCompendium.h"

#include <functional>

namespace AbstractRealm
{
	class State : RealmControl
	{
	public:
		 State();

		~State();

		void initalize();
		void deInit   ();

		void update();
		void render();

			 bool   active;
		std::string	name  ;
	};
}