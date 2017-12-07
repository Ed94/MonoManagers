#pragma once
#include "State.h"

#include "../Space/2DObjects.h"
#include "../Shader/shaders.h"


namespace AbstractRealm
{
	class AR_States : RealmControl
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