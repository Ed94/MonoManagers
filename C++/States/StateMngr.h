#pragma once
#include "State.h"

#include "../Space/2DObjects.h"
#include "../Shader/shaders.h"
#include "../Space/TestObjects.h"

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