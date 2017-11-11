#pragma once
#include "AR.h"
#include "State.h"
#include "boost\function\function_base.hpp"

namespace AbstractRealm
{
	class StateMngr
	{
	public:
		 StateMngr();
		~StateMngr();

		void setCRTState(State state, AssetMngr assetMngr);

		void initalizeState();
		void deinitalize   ();
		void updateStates  ();
		void drawStates    ();

	private:
		State crtState;

		State rectTest;

		//Rectangle Related Shit
		std::string rectName;

		void setupRectTest();

		void rectInit  ();
		void rectDeInit();
		void rectUpdate();
		void rectrender();

		//AR_StateCompendium arStates;
	};
}