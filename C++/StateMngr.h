#pragma once
#include "2DObjects.h"
#include "shaders.h"
#include "State.h"
#include "TestObjects.h"

#include <GL\glew.h >
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