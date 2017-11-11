#include "Assets.h"

namespace AbstractRealm
{
	Asset::Asset()
	{
		name     = "";
		location = "";
	}

	Asset::Asset(std::string namePassed, fs::path locationPassed)
	{
		name     = namePassed	 ;
		location = locationPassed;
	}
}
