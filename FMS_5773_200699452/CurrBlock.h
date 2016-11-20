#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "PhysicalBlockclass.h"
using namespace std;
//CurrBlock class use of PhysicalFile class.
class CurrBlock
{

  public:
	unsigned int Nr;//fields:Serial Number and buffer.
	PhysicalBlock Buffer;

	CurrBlock(void):Nr(NULL){}//constructor.
};
