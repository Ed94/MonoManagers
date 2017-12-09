#pragma once

#include <functional>

namespace AbstractRealm
{
	class State
	{
	public:
		 State();

		 State(std::string name,
			   std::function<void()> initDelegate  ,
			   std::function<void()> deInitDelegate,
			   std::function<void()> updateDelegate,
			   std::function<void()> renderDelegate );

		~State();

		std::function<void()> initDelegate  ;
		std::function<void()> deInitDelegate;
		std::function<void()> updateDelegate;
		std::function<void()> renderDelegate;

			 bool   active;
		std::string	name  ;
	};
}