#include "AR.h"

namespace AbstractRealm
{
	bool RealmControl::exist = true;

	RealmControl::RealmControl()
	{

	}

	RealmControl::~RealmControl()
	{

	}

	void RealmControl::errorHandler(std::string errorMsg)
	{
		std::cout << errorMsg << std::endl;

		std::cout << "Enter any key to quit";

		int tmp;

		std::cin >> tmp;

		cease();
	}

	void RealmControl::update()
	{
		errorHandler("Update called from a realm control enabled structure decieded to use virtual definition.");
	}

	void RealmControl::render()
	{
		errorHandler("Render called from a realm control enabled structure decieded to use virtual definition.");
	}

	void RealmControl::cease()
	{
		exist = false;
	}

	bool RealmControl::getExist()
	{
		return exist;
	}
}