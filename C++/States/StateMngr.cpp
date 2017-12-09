#include "StateMngr.h"

namespace AbstractRealm
{
	StateMngr:: StateMngr() { printf("State Manager created.\n"); }
	StateMngr::~StateMngr()										{ }

	void StateMngr::setCRTState(State state)
	{
		crtState = state;

		initalizeState();
	}

	void StateMngr::initalizeState() { crtState.initDelegate  (); }
	void StateMngr::destructState () { crtState.deInitDelegate(); }
	void StateMngr::updateState   () { crtState.updateDelegate(); }
	void StateMngr::drawState	  () { crtState.renderDelegate(); }
}