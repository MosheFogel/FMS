#pragma once
#include"PhysicalFileClass.h"
#include"CurrBlock.h"
#include"PhysicalBlockclass.h"
#include"LogicalBlock.h"
#include"LogicalFileHeader.h"
#include"HashValue.h"
#include<iostream>
#include<time.h>
#include<string>
#include<stdio.h>
using namespace std;


class hashfile
{
public:

	//fields of hashfile class.
	//*************************
	PhysicalFile MyFile;
	HashValue hashfunction;
	HashFuncIDcode hashIdCode;
	string UserName;
	LogicalBlock *LogicalBuffer;
	bool updateflag;
	bool LBuffChanged;
	bool is_open();
	string open_mode();
	LogicalFileHeader *LogicalFHBuffer;
	int CurrRecNrInBuffer;
	int limit;
	bool LHBuffChanged;
	int write_state; // *****we are added.*****

	string lastErrorMessage;
	//functions of hashfile class.
	//****************************
	string& GetLastErrorMessage();
	void SetLastErrorMessage(string lastErrorMessage);
	/*************************************************
	* FUNCTION:
	* defoult constructor.
	* PARAMETERS:
	* none.
	* RETURN VALUE:
	* none.
	* MEANING:
	* defoult constructor that initialize all the 
	* fields they are logical, in addition call to the
	* defoult constructor of the phisical file class
	* SEE ALSO
	* defoult constructor of the phisical file class.
	**************************************************/
	hashfile(void);
	/*************************************************
	* FUNCTION:
	* constructor.
	* PARAMETERS:
	* 1)file name (without suffix),2)user name (who is
	* the file's owner),3) record's length (in bytes),
	* 4) full path,5) file's size (in blocks),6) key's
	* location,7) type of key's data,8) key's length 
	* (in bytes).
	* RETURN VALUE:
	* none.
	* MEANING:
	* This constructor is initialize hash file's object
	* for hase file creating,by calling to the function 
	* hcreate.
	* SEE ALSO
	* function hcreate
	**************************************************/
	hashfile(string, string, unsigned int, string, unsigned int, unsigned int, string, unsigned int , unsigned int);
	/*************************************************
	* FUNCTION:
	* constructor.
	* PARAMETERS:
	* 1)file name (without suffix),2)user name (who is
	* the file's owner or request to open the file),
	* 3) full path,4) how to open the file (writing,
	* reding,both)
	* RETURN VALUE:
	* none.
	* MEANING:
	* This constructor is initialize hash file's object
	* for hase file opening(logicaly and physically),
	* by calling to the function hopen.
	* SEE ALSO
	* function hopen.
	**************************************************/
	hashfile(string, string, string, string);
	/*************************************************
	* FUNCTION:
	* distructor.
	* PARAMETERS:
	* none.
	* RETURN VALUE:
	* none.
	* MEANING:
	* distructor that destroy such kind of class
	* otomatically in the time. the function do file's
	* closing (by calling to the hclose function) if
	* the file is still opened.
	* SEE ALSO
	* function hclose.
	**************************************************/
	~hashfile(void);
	/*************************************************
	* FUNCTION:
	* hcreate.
	* PARAMETERS:
	* 1)file name (without suffix),2)user name (who is
	* the file's owner),3) record's length (in bytes),
	* 4) full path,5) file's size (in blocks),6) key's
	* location,7) type of key's data,8) key's length 
	* (in bytes).
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function create hash file physically (by 
	* calling function pcreat) and complete the 
	* creation process logicaly, at least close the 
	* file physically (by calling function pclose).
	* SEE ALSO
	* functions: pclose,pcreat.
	**************************************************/
	void hcreate(string ,string ,unsigned int ,string ,unsigned int ,unsigned int ,string ,unsigned int, unsigned int);
	/*************************************************
	* FUNCTION:
	* hdelete.
	* PARAMETERS:
	* none.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function delete the file (by calling 
	* function pdelete) only if the file is closed
	* SEE ALSO
	* function pdelete.
	**************************************************/
	void hdelete(void);
	/*************************************************
	* FUNCTION:
	* hopen.
	* PARAMETERS:
	* 1)file name (without suffix),2)user name (who is
	* the file's owner or request to open the file),
	* 3) full path,4) how to open the file (writing,
	* reding,both)
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function open exist file-physically (by 
	* calling the function popen) and logicaly (by 
	* pdateing the necessary fields:LHBUffChanged,
	* LBuffChanged and UserName).The file will open by 
	* the value of the fourth parameter (with 
	* limitations according to each case).
	* SEE ALSO
	* function popen.
	**************************************************/
	void hopen(string ,string ,string ,string);
	/*************************************************
	* FUNCTION:
	* hclose.
	* PARAMETERS:
	* none.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function close the file in two stages:1) 
	* calling the function flush with parameter 2, 2)
	* calling the function pclose which close the file
	* physically.
	* SEE ALSO
	* functions: flush,pclose.
	**************************************************/
	void hclose();
	/*************************************************
	* FUNCTION:
	* flush.
	* PARAMETERS:
	* kode (or 0 or 1 or 2).
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function making physicaly writing of the 
	* buffer of the current block or the buffer of file 
	* header or both according to eccepted value.the 
	* functions that will be activated: writeFH or 
	* writeBlock or both respectively.
	* SEE ALSO
	* functions: writeBlock,writeFH.
	**************************************************/
	void flush(int);

	/*************************************************
	* FUNCTION:
	* read.
	* PARAMETERS:
	* key of the record ,pointer to record,type of 
	* reading (to update
	* or not).
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function read record from the file if it 
	* exist.
	* SEE ALSO
	* functions: seek , helpseek ,
	* Check_If_Key_Is_In_This_Block.
	**************************************************/
	void read(string &, char*,int);
	void read(char* ,char* ,int);
	void read(int , char* , int);
	
	/*************************************************
	* FUNCTION:
	* write.
	* PARAMETERS:
	* key of a record, pointer to a record which will 
	* write into the block.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function write record into the file if it 
	* had not be writen.
	* SEE ALSO
	* functions: seek , helpseek ,
	* Check_If_Key_Is_In_This_Block
	* Check_free_space_In_Block.
	**************************************************/
	void write(string& ,char*);
	void write(char* ,char*);
	void write( int , char*);

	/*************************************************
	* FUNCTION:
	* string IntToString.
	* PARAMETERS:
	* veriable of int type.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function is help function which take 
	* veriable of int type and convert it to string.
	**************************************************/
	string IntToString (int );
	string FloatToString(float);

	void Delrec(void);
	void Update(char*);
	void updateoff(void);
	void Del_rec_Casing(char*);
	void Press_Bloak(char*);
	void Press_Block_OV();
	int Serch_key_by_hash(int);

 //  private:
	/*************************************************
	* FUNCTION:
	* seek.
	* PARAMETERS:
	* key of a record.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function searching key of desired record in 
	* all the file.
	* SEE ALSO
	* functions:helpseek
	* Check_If_Key_Is_In_This_Block
	* Check_free_space_In_Block.
	**************************************************/
	void seek(string &);
	void seek(char *);  
	void seek(int);

	/*************************************************
	* FUNCTION:
	* helpseek
	* PARAMETERS:
	* hash number,key of a record.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function searching key of desired record in 
	* all the file.
	**************************************************/
	void helpseek(int,char []);

	/*************************************************
	* FUNCTION:
	*  helpwrite.
	* PARAMETERS:
	* key of a record , a record.
	* RETURN VALUE:
	* none.
	* MEANING:
	* this function write a record to a file.
	**************************************************/
	void helpwrite(int , char*);
	/*************************************************
	* FUNCTION:
	* Check_If_Key_Is_In_This_Block.
	* PARAMETERS:
	* key of a record , a record.
	* RETURN VALUE:
	* flag if this key exist in the block or not.
	* MEANING:
	* this function searching key of desired record in 
	* sume block.
	**************************************************/
	bool Check_If_Key_Is_In_This_Block(int,char[]);
	/*************************************************
	* FUNCTION:
	* Check_free_space_In_Block.
	* PARAMETERS:
	* a record.
	* RETURN VALUE:
	* flag if there is empty space in size of a record
	* in this block.
	* MEANING:
	* this function searching empty place in size of 
	* a record in this block.
	**************************************************/
	bool Check_free_space_In_Block(char[]);
	float load_factor();
	char* filename();
	char* OwnerName();
	char* CreationDate();
	int FileSize();
	int RecordSize();
	int HashFuncID();
	int NrOfRecsInFile();
	int OverflowAreaStart();
	
	private:
};
