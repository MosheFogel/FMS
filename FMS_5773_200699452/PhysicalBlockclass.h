#pragma once
#include <iostream>
#include <string>
#include <fstream>
using namespace std;

//CurrBlock class use of CurrBlock class and PhysicalFile class.
class PhysicalBlock
{
  public:
    //int BlockNr;
    char filler [20];//fields.
	char data[1000];


	PhysicalBlock(void);//defoult constructor.
	void filltrash(void);// function to fill trash at the file.
};