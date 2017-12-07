#include "../Core/AR.h"

namespace AbstractRealm
{	
	RealmControl:: RealmControl() { }
	RealmControl::~RealmControl() { }

	void RealmControl::errorHandler(std::string errorMsg)
	{
		std::cout << errorMsg << std::endl;

		std::cout << "Enter any key to quit";

		int tmp;

		std::cin >> tmp;

		cease();
	}

	void RealmControl::update()
	{ errorHandler("Update called from a realm control enabled structure decieded to use virtual definition."); }

	void RealmControl::render()
	{ errorHandler("Render called from a realm control enabled structure decieded to use virtual definition."); }

	bool RealmControl::getExist() { return exist ; }
	void RealmControl::cease   () { exist = false; }

	bool RealmControl::exist = true;

	InputMngr *RealmControl::inputMngrPtr;
	UserMngr  *RealmControl::userMngrPtr ;
}