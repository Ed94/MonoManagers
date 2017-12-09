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
		State inputSel;
		State rectTest;

	private:
		/*   Launch States    */
		//--------------------//
		/*   Input Select     */
		std::string inputSelName;

		void setupInputSel();

		void inputSelInit  ();
		void inputSelDeInit();
		void inputSelUpdate();
		void inputSelRender();

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