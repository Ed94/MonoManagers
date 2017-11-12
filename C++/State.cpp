#include "State.h"

namespace AbstractRealm
{
	State::State()
	{
		name = "This state was not properly initalized.";
	}

	State::State(std::string name					 ,
				 std::function<void()> initDelegate  ,
				 std::function<void()> deInitDelegate,
				 std::function<void()> updateDelegate,
				 std::function<void()> renderDelegate)
	{
		this->name = name;
		this->initDelegate   = initDelegate  ;
		this->deInitDelegate = deInitDelegate;
		this->updateDelegate = updateDelegate;
		this->renderDelegate = renderDelegate;
	}

	State::~State() {}
}