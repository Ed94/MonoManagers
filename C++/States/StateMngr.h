#pragma once
#include "State.h"

#include <functional>

namespace AbstractRealm
{
	class StateMngr
	{
	public:
		 StateMngr();
		~StateMngr();

		void setCRTState(State state);

		void initalizeState();
		void destructState ();
		void updateState   ();
		void drawState     ();

	private:
		State crtState;
	};
}