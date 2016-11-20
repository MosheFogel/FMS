#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "PhysicalBlockclass.h"
using namespace std;


PhysicalBlock::PhysicalBlock(void)//defoult constructor
{
	for(int i=0;i<20;++i)
		filler[i]='\0';
	for(int j=0;j<1000;++j)
		data[j]='\0';
};

void PhysicalBlock::filltrash(void)// function to fill trash at the file.
{
	for(int i=0;i<20;++i)
		filler[i]='\0';
	for(int j=0;j<1000;++j)
		data[j]='\0';
}