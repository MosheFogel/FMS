#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include "CurrBlock.h"
#include "PhysicalBlockclass.h"
using namespace std;
//the main class.
class PhysicalFile
{

  public:
	bool opened;
	string openmode;
	string WorkingDir;
	string FileName;
	int FileSize;
	fstream Filefl;
	CurrBlock cb;
	PhysicalBlock FHBuffer;


/*************************************************
* FUNCTION
* defoult constructor.
* PARAMETERS
* none.
* RETURN VALUE
* none.
* MEANING
* פונקציית בנאי שמאתחלת בערכים דיפולטיביים את 
* המחלקה פיסיקל פייל
**************************************************/
    PhysicalFile(void);
/*************************************************
* FUNCTION:
* constructor to create file.
* PARAMETERS:
* string-file name without ending,nsigned int-size 
* of file in blocks,string-full path of the file. 
* RETURN VALUE:
* none.
* MEANING:
* constructor function that make a new file and 
* initializes the phisicalfile class's values
* by values which the user gives.
* SEE ALSO:
* this functio based on pcreate's function see the
* documentation over there.
**************************************************/
	PhysicalFile(string,unsigned int,string);
/*************************************************
* FUNCTION:
* constructor to existing file.
* PARAMETERS:
* string-file name without ending,string-mode how  
* to open the file,string- full path of the file. 
* RETURN VALUE:
* none.
* MEANING:
* constructor function that initializes the 
* phisicalfile class's values by values which
* the user gives and open existing file phisicaly.
* SEE ALSO:
* this functio based on popen's function see the
* documentation over there.
**************************************************/
    PhysicalFile(string,string,string);
/*************************************************
* FUNCTION:
* destructor.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* destructor function that destroy the object 
* without erasing any files by closing the file if
* it exist.
* SEE ALSO:
* this functio using  pclose's function see the
* documentation over there.
**************************************************/
	~PhysicalFile(void);
/*************************************************
* FUNCTION:
* pcreate.
* PARAMETERS:
* string-file name without ending,string-mode how  
* to open the file,string- full path of the file. 
* RETURN VALUE:
* none.
* MEANING:
* function that creat and initielize a new file and  
* initielize the phisicalfile class's values by
* values which the user gives.
* SEE ALSO:
* this functio using  pclose's function see the
* documentation over there.
**************************************************/
	void pcreate(string,unsigned int,string);
/*************************************************
* FUNCTION:
* pdelete.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that delete existing file. (of cours 
* check if it exist and close it before the deletion.
* SEE ALSO:
* this functio using  pclose's function see the
* documentation over there.
**************************************************/
	void pdelete(void);
/*************************************************
* FUNCTION:
* popen.
* PARAMETERS:
* string-file name without ending,string-mode how  
* to open the file,string- full path of the file.
* RETURN VALUE:
* none.
* MEANING:
* function that open file either ride or wright or 
* both of them and updateing the Appropriate filds.
* (of cours chack if it exist and so on.)
* SEE ALSO:
* this functio using  pclose's function see the
* documentation over there.
**************************************************/
	void popen(string,string,string);
/*************************************************
* FUNCTION:
* pclose.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that close open file and updateing the
* openmode field to close (false).
* (of cours chack if it allready closed and so on.)
* SEE ALSO:
* this functio based on readFH's function see the
* documentation over there.
**************************************************/
	void pclose(void);
/*************************************************
* FUNCTION:
* SeekToBlock.
* PARAMETERS:
* unsigned int-the block number we want the 
* read/wright head to.
* RETURN VALUE:
* none.
* MEANING:
* function that updat the Serial Number' field of
* cuurent block class with some desired number,so 
* next time read/wright head will move to this block.
* (of cours chack if the number doasn't bigger than
* the size of file)
**************************************************/
	void SeekToBlock(unsigned int);
/*************************************************
* FUNCTION:
* writeBlock.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that write some block from the buffer 
* into the file in somewhat place and update the 
* Serial Number' field of cuurent block class by +1.
**************************************************/
	void writeBlock(void);
/*************************************************
* FUNCTION:
* readBlock.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that read some block from the file 
* into the buffer in the object and update the 
* Serial Number's field of cuurent block class by +1.
**************************************************/
	void readBlock(void);
/*************************************************
* FUNCTION:
* writeFH.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that wright the file header's block 
* from the FHbuffer field into the first block of 
* the file and update the Serial Number's field of
* cuurent block class by value 1.
**************************************************/
	void writeFH(void);
/*************************************************
* FUNCTION:
* writeFH.
* PARAMETERS:
* none.
* RETURN VALUE:
* none.
* MEANING:
* function that read the file header's block 
* from the first block of the file into the FHbuffer
* field and update the Serial Number's field of
* cuurent block class by value 1.
**************************************************/
	void readFH(void);
};

