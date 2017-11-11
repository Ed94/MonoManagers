#include "StateMngr.h"

namespace AbstractRealm
{
	StateMngr::StateMngr()
	{
		printf("State Manager Started.");
	}

	StateMngr::~StateMngr()
	{

	}

	void StateMngr::setCRTState(State state, AssetMngr assetMngr)
	{
		crtState = state;
	}

	void StateMngr::initalizeState()
	{
		crtState.initalize();
	}

	void StateMngr::deinitalize()
	{
		crtState.deInit();
	}

	void StateMngr::updateStates()
	{
		crtState.update();
	}

	void StateMngr::drawStates()
	{
		crtState.render();
	}



	//Rectangle Test
	void StateMngr::rectInit()
	{
	}

	void StateMngr::rectDeInit()
	{
	}

	void StateMngr::rectUpdate()
	{
	}

	void StateMngr::rectrender()
	{
	}

	void StateMngr::setupRectTest()
	{
		rectName = "Rectangle Test";

	}
}