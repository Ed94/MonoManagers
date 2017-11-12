#pragma once
#include "State.h"
#include "shaders.h"
#include "2DObjects.h"

namespace AbstractRealm
{
	class AR_States
	{
	public:
		 AR_States();
		~AR_States();

		void setupStates();

		//State List
		State rectTest;

	private:
		/*    Test States     */
		//--------------------//
		/*   Rectangle Test   */
		std::string rectName;

		void setupRectTest();

		void rectInit  ();
		void rectDeInit();
		void rectUpdate();
		void rectRender();

		Sprite			 sprite;
		GLSL_Core	colorShader;
		//----------------------
	};
}