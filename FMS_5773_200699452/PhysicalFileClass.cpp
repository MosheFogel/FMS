#include "PhysicalFileClass.h"


PhysicalFile::PhysicalFile()
{
	opened=false;
	openmode='\0';
	WorkingDir='\0';
	FileName='\0';
	FileSize=0;
}

PhysicalFile::PhysicalFile(string fn,unsigned int fs=0,string pa="")
{
	pcreate(fn,fs,pa);
}

PhysicalFile::PhysicalFile(string Fn,string Om="I",string Pa="")
{
	string fullpath=Pa+"\\"+Fn+".hash";
	Filefl.open(fullpath , ios::in);
	if(! Filefl.is_open())
	{
		string err="ERROR! The file can not be open!(probably the file doasn't exist.)";
		throw err;
	}
	popen(Fn,Om,Pa);
}

PhysicalFile::~PhysicalFile(void)
{
	if(opened==true)
	{
		pclose();
	}
}

void PhysicalFile::pcreate(string filename,unsigned int filesize=NULL,string path="")
{
	string err;
	string fullPath=path ;
	//file path
	if(path=="")
		fullPath=	path + filename + ".hash" ;
	else
		fullPath= path +"\\" + filename +".hash";

	if(filesize==0)//if the size hadn't been entered-
	{              //posting defoult size.
		filesize=1000;
	}

	WorkingDir=fullPath;
	FileName= filename;
	FileSize=filesize;

	Filefl.open(fullPath , ios::in);
	if(Filefl.is_open())
	{
		Filefl.close();
		err="ERROR! The file allready exsits!";
		throw err;
	}

	Filefl.open(fullPath ,ios::out | ios::binary); ///change to workingdir
	if(Filefl.is_open())
	{
		opened=true;
		cb.Nr=0;
		writeFH(); /////
		this->cb.Buffer.filltrash();
		for(int i=1;i < filesize;i++)
		{
			SeekToBlock(i);
			writeBlock();
		}
		pclose();
	}
	else
	{
		err="ERROR! The file can not be open!(probably the file doasn't exist.)";
		throw err;
	}
}

void PhysicalFile::writeBlock()
{
	string err;
	if((openmode == "o" || openmode == "O" || openmode == "io" ||openmode == "IO" )&& opened)
	{
		SeekToBlock(cb.Nr);
		Filefl.write((const char*)&(cb),sizeof(cb));
		cb.Nr++;
	}
	else if(opened==true &&(openmode=="i" || openmode == "I"))
	{
		err="You can't write into the file because it's opened for read only!";
	   throw err;
	}
	else
	{
		err="You can't write into the file because it's closed!";
		throw err;
	}
}

void PhysicalFile::readBlock()
{
	string err;
	if(opened &&(openmode=="I"|| openmode=="i" ||openmode=="IO"||openmode=="io"))
	{
		SeekToBlock(cb.Nr);
		Filefl.read((char*)&(cb),sizeof(cb));
		cb.Nr++;
	}
	else if(opened &&(openmode!="I"|| openmode!="i"))
	{
		err="Reading can't be done becouse the file open to write only!";
		throw err;
	}
	else
	{
		err="Reading can't be done becouse the file is closed!";
		throw err;
	}
}

void PhysicalFile::pclose()
{
	if(Filefl.is_open())//chacking if the file is open:
	{                         //closing,update opened field.
		Filefl.close();
		opened=false;
	}
	else//exception if the file is close allready.
	{
		opened=false;
		string err="ERROR! the file allready closed!";
		throw err;
	}
	
}

void PhysicalFile::pdelete()
{
	if(this->Filefl.is_open())//if the file is open:closing,removing of file
	{                         //updating of all relevant fields.
		this->pclose();
	}
	remove(WorkingDir.c_str());
	FileName="";
	FileSize=0;
	openmode="";
	opened=false;
	WorkingDir="";
}

void PhysicalFile::writeFH()
{
	string err;
	if((openmode == "o" || openmode == "O" || openmode == "io" ||openmode == "IO" )&& opened)
	{
		SeekToBlock(0);
		Filefl.write((const char*) &(this->FHBuffer),sizeof(CurrBlock));
		cb.Nr=1;
	}
	else if(opened==true &&(openmode=="i" || openmode == "I"))
	{
		err="You can't write into the file because it's opened for read only!";
		throw err;
	}
	else
	{
		err="You can't write into the file because it's closed!";
		throw err;
	}
}

void PhysicalFile::readFH()
{
	if(opened)
	{
		cb.Nr=0;
		Filefl.read((char*)&(this->FHBuffer),sizeof(PhysicalBlock));
		cb.Nr=1;
	}
	else if(!opened)
	{
		string err="Reading can't be done becouse the file is closed!";
		throw err;
	}
}

void PhysicalFile::SeekToBlock(unsigned int desiredNum)
{
	string err;
	if(!opened)
	{
		err="The file is not open!";
        throw err;
	}
	else if(desiredNum > (FileSize))//exception if the number bigger than size 
	{                               //of the file.
		err="OVERFLOW!";
		throw err;
	}
	//the number proper:updating updating of
	//Serial Number field with the number.
	Filefl.seekg(desiredNum*sizeof(CurrBlock));
	Filefl.seekp(desiredNum*sizeof(CurrBlock));
	cb.Nr=desiredNum;
}

void PhysicalFile::popen(string filename,string opMode="I",string path="")
{
	string fullPath;
	if(!Filefl.is_open())
	{	
		if(path=="")
			fullPath=path + filename + ".hash" ;
		else
			fullPath= path +"\\" + filename +".hash";
	}
	FileName=filename;
	openmode=opMode;
	WorkingDir=fullPath; 
	Filefl.open(WorkingDir,ios::in);      //opening to reading.
	if(!Filefl.is_open())//exception if the open of the file failed. 
	{
		string err="ERROR! The file can not be open!(probably the file doasn't exist.)";
		throw err;
	}

	if(this->openmode=="I"||this->openmode=="i")//opening to read situation:
	{                                           //update opened and Serial Number fields.
		opened=true;	
		readFH();
	}
	else if(openmode=="IO"||openmode=="io"||openmode=="O"||openmode=="o")
	{
		Filefl.close();
		Filefl.open(WorkingDir,ios::in|ios::out| ios::binary);
		opened = true;

		readFH();
	}
}

