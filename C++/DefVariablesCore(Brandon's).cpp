#include "AR.h"
#include <string>
#include <iostream>

using namespace std;
using namespace AbstractRealm;

void Core::setsomething()
{
	something = 10;
}

int Core::getsomething()
{
	return something;
}

void Core::printsomething()
{
	string somethingtostring = to_string(something);

	cout << somethingtostring;
}