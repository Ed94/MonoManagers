#include "AR_States.h"

namespace AbstractRealm
{
	AR_States:: AR_States() { setupStates(); }
	AR_States::~AR_States()				   { }

	void AR_States::setupStates()
	{
		setupInputSel();
		setupRectTest(); 
	}


	//Input Select
	void AR_States::inputSelInit()
	{

	}

	void AR_States::inputSelDeInit()
	{

	}

	void AR_States::inputSelUpdate()
	{
		if (userMngrPtr->checkPress(AccessLevel::Host, InputStates::Menu, (unsigned int)MenuControls::Cease))
		{
			cease();
		}
	}

	void AR_States::inputSelRender()
	{

	}

	void AR_States::setupInputSel()
	{
		inputSelName = "Input Select";

		inputSel = State(inputSelName,
						 std::bind(&AR_States::inputSelInit  , this),
						 std::bind(&AR_States::inputSelDeInit, this),
						 std::bind(&AR_States::inputSelUpdate, this),
						 std::bind(&AR_States::inputSelRender, this) );
	}


	//Rectangle Test
	void AR_States::rectInit()
	{
		sprite.initialize(0.0f, 0.0f, 1.0f, 1.0f);

		colorShader.createShaders("Shader\\colorShading.vert", "Shader\\colorShading.frag");
		colorShader.addAttribute ("vertexPosition"										  );
		colorShader.addAttribute ("vertexColor"											  );
		colorShader.linkShaders															 ();
	}

	void AR_States::rectDeInit() { }

	void AR_States::rectUpdate() 
	{
		if (this->userMngrPtr->checkPress(AccessLevel::Host, InputStates::Menu, (unsigned int)MenuControls::Select))
		{
			stateMngrPtr->setCRTState(inputSel);
		}

		if (this->userMngrPtr->checkPress(AccessLevel::Host, InputStates::Menu, (unsigned int)MenuControls::Cease))
		{
			cease();
		}
	}

	void AR_States::rectRender()
	{
		colorShader.add   ();
		sprite	   .render();
		colorShader.remove();
	}

	void AR_States::setupRectTest()
	{
		rectName = "Rectangle Test";

		rectTest = State(rectName,
						 std::bind(&AR_States::rectInit  , this),
						 std::bind(&AR_States::rectDeInit, this),
						 std::bind(&AR_States::rectUpdate, this),
						 std::bind(&AR_States::rectRender, this) );
	}
}