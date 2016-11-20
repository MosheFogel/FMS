#include "hashfile.h"
#include"HashValue.h"
#include<ctime>
#include<string>
#include<sstream>

int rec_loc=0;
char * str1=new char[8];

string& hashfile::GetLastErrorMessage()
{
	return this->lastErrorMessage;
} ////////////////




void hashfile::SetLastErrorMessage(string lastErrorMessage)
{
	this->lastErrorMessage = lastErrorMessage;
} 


//the function convert int to string in return the string
string hashfile::IntToString (int a)
{
	string str;
	ostringstream temp;
	temp<<a;
	return temp.str();
} ////// //////////

string hashfile::FloatToString(float a)
{
	string str;
	ostringstream temp;
	temp<<a;
	return temp.str();
}

//Default ctor
hashfile::hashfile(void)
{
	LogicalBuffer = ((LogicalBlock*)&MyFile.cb);
	LogicalFHBuffer = ((LogicalFileHeader*)&MyFile.FHBuffer);
	LBuffChanged=false;
	LHBuffChanged=false;
	write_state=0;
	limit= 0;
	UserName="";

}


// ctor for creating file
hashfile::hashfile(string filenam, string usernam,unsigned int longrecord, string path ,unsigned int sizefile,
				   unsigned int keyloc ,string type,unsigned int keylong, unsigned int hashfunci)
{
	LogicalBuffer = ((LogicalBlock*)&MyFile.cb);
	LogicalFHBuffer = ((LogicalFileHeader*)&MyFile.FHBuffer);
	LBuffChanged=false;
	LHBuffChanged=false;
	write_state=0;
	limit= 0;
	MyFile.FileName= filenam;
	UserName= usernam;
	LogicalFHBuffer->RecordSize= longrecord;
	LogicalFHBuffer->FileSize = sizefile;
	hcreate(filenam,usernam,longrecord,path,sizefile,keyloc,type,keylong,hashfunci);
}

// ctor for opening file
hashfile::hashfile(string filenam, string usernam, string path, string openway)
{
	LogicalBuffer = ((LogicalBlock*)&MyFile.cb);
	LogicalFHBuffer = ((LogicalFileHeader*)&MyFile.FHBuffer);
	LBuffChanged=false;
	write_state=0;
	LHBuffChanged=false;
	MyFile.FileName= filenam;
	UserName= usernam;
	MyFile.openmode= openway;
	hopen(filenam ,usernam, path ,openway);
}

// dtor
hashfile::~hashfile(void)
{
	if(MyFile.opened==true)
	{
		if(MyFile.Filefl.is_open())
			hclose();
	}
}

// create a new file
void hashfile::hcreate(string filenam="", string usernam="",unsigned int longrecord=0, string path="" ,unsigned int sizefile=0 ,
					   unsigned int keyloc=0 ,string type="I" ,unsigned int keylong=4, unsigned int hashfuncid=1)
{
	if (updateflag==true)
	{
		string err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	hashIdCode =static_cast<HashFuncIDcode>(hashfuncid);
	HashValue tmp(sizefile*0.7);
	hashfunction = tmp;
	LogicalFHBuffer->BlockNr=0;
	LogicalFHBuffer->HashFuncID= hashfuncid;
	LogicalFHBuffer->NrOfRecsInFile=0;
	LogicalFHBuffer->KeySize=keylong;
	_strdate(LogicalFHBuffer->CreationDate);
	strcpy(LogicalFHBuffer->FileName ,filenam.c_str());
	LogicalFHBuffer->KeyOffset = keyloc;
	LogicalFHBuffer->FileSize = sizefile;
	strcpy(LogicalFHBuffer->KeyType ,type.c_str());
	strcpy(LogicalFHBuffer->OwnerName ,usernam.c_str());
	LogicalFHBuffer->RecordSize = longrecord;

	LogicalFHBuffer->OverflowAreaPtr = hashfunction.maxHval();
	LogicalFHBuffer->OverflowAreaStart= hashfunction.maxHval();

	MyFile.FileName = filenam;
	MyFile.FileSize = sizefile;
	MyFile.openmode = type;
	// file creating physically
	MyFile.pcreate(filenam ,sizefile ,path);
	// opennig file to fill the file header.
	MyFile.popen(filenam,"IO",path);
	MyFile.writeFH();
	LogicalBuffer->OverflowBlockPtr=0;
	LogicalBuffer->NrOfOverflowedRecs=0;
	LogicalBuffer->NrOfRecsInBlock=0;
	limit= 1000/LogicalFHBuffer->RecordSize;
	limit *=  LogicalFHBuffer->RecordSize;
	for(int i=1; i<LogicalFHBuffer->OverflowAreaPtr ;i++)
	{
		MyFile.writeBlock();
	}
	for(int j=LogicalFHBuffer->OverflowAreaPtr ; j< sizefile ;j++)
	{
		if((MyFile.cb.Nr+1) == MyFile.FileSize)
		{ 
			LogicalBuffer->OverflowBlockPtr= NULL;
		}
		else
		{ LogicalBuffer->OverflowBlockPtr =(1+ MyFile.cb.Nr); }
		MyFile.writeBlock();
	}
	hclose();

}
// File deletion function.
void hashfile::hdelete()
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
		MyFile.pdelete();
	else
	{
		err="ERROR! the file is still open please close it.";
		throw err;
	}
}

void hashfile::hopen(string filename , string usernam , string path , string openmode)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	MyFile.popen(filename,"I" , path);
	MyFile.FileSize = LogicalFHBuffer->FileSize;
	if(openmode == "i" || openmode == "I")
	{
		LBuffChanged=false;
		LHBuffChanged=false;
		limit= 1000/LogicalFHBuffer->RecordSize;
		limit *=  LogicalFHBuffer->RecordSize;
		//UserName= usernam;
	}
	else if(LogicalFHBuffer->OwnerName == usernam )
	{
		MyFile.pclose();
		MyFile.popen(filename,openmode , path);
		LBuffChanged=false;
		LHBuffChanged=false;
		UserName= usernam;
		limit= 1000/LogicalFHBuffer->RecordSize;
		limit *=  LogicalFHBuffer->RecordSize;
	}
	else
	{
		err="ERROR! the user name is not the owner of the file.";
		throw err;
	}

} //////////

void hashfile::hclose()
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(! MyFile.opened)
	{
		err = "The file is closed allready ";
		throw err;
	}
	flush(2);
	MyFile.pclose();
}


void hashfile::flush(int num)
{
	if(MyFile.opened)
	{
		switch(num)
		{
		case 0:
			{
				if(LHBuffChanged==true)

					MyFile.writeFH();
				LHBuffChanged=false;
				break;
			}
		case 1:
			{
				if(LBuffChanged==true)
					MyFile.writeBlock();
				LBuffChanged=false;
				break;
			}
		case 2:
			{
				if(LHBuffChanged==true && LBuffChanged==true)
				{
					MyFile.writeBlock();
					MyFile.writeFH();
					LBuffChanged=false;
					LHBuffChanged=false;
				}
				if(LBuffChanged==true)
				{
					MyFile.writeBlock();
					LBuffChanged=false;
				}

				if(LHBuffChanged==true)
				{
					MyFile.writeFH();
					LHBuffChanged=false;
				}
				break;
			}
		}
	}
	else
	{
		string err="The file is not open to IO or O.";
		throw err;
	}
}

void hashfile::seek(char *Key)
{
	int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID,Key,(MyFile.FileSize*0.7));
	if(hashNum == 0)
		hashNum =1;
	if(MyFile.cb.Nr ==hashNum)
	{
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,Key);
	}
	else
	{
		flush(1);
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,Key);
	}

}

void hashfile::seek(int key)
{
	char* T=new char[LogicalFHBuffer->KeySize];
	strcpy(T ,IntToString(key).c_str());
	int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID,T,(MyFile.FileSize*0.7));
	if(hashNum == 0)
		hashNum =1;
	if(MyFile.cb.Nr ==hashNum)
	{
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,T);
	}
	else
	{
		flush(1);
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,T);
	}

}

void hashfile::seek(string &key)
{
	char *W =new char[LogicalFHBuffer->KeySize];
	strcpy(W ,key.c_str());
	int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID , W,(MyFile.FileSize*0.7));    
	if(hashNum == 0)
		hashNum =1;
	if(MyFile.cb.Nr ==hashNum)
	{
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,W);
	}
	else
	{
		flush(1);
		MyFile.SeekToBlock(hashNum);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		helpseek(hashNum,W);
	}
	delete []W;
}

void hashfile::read(string& key ,char* record , int opmod)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="o"||MyFile.openmode=="O")
	{
		err="The file is open to write only!";
		throw err;
	}
	if(opmod==1)
	{
		updateflag=true;
	}
	write_state=0;
	seek(key);
	memcpy(record,MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer,(LogicalFHBuffer->RecordSize+1));
	if(opmod ==1)
		updateflag = true;
}

bool hashfile::is_open()
{
	return MyFile.opened; 
}
string hashfile::open_mode()
{
	return MyFile.openmode;
}

void hashfile::read(char* key ,char* record , int opmod )
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="o"||MyFile.openmode=="O")
	{
		err="The file is open to write only!";
		throw err;
	}
	if(opmod==1)
	{
		updateflag=true;
	}
	write_state=0;
	seek(key);
	memcpy(record,hashfile::MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer,(LogicalFHBuffer->RecordSize+1));
	if(opmod ==1)
		updateflag = true;
}

void hashfile::read(int key ,char* record ,int opmod)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="o"||MyFile.openmode=="O")
	{
		err="The file is open to write only!";
		throw err;
	}

	if(opmod==1)
	{
		updateflag=true;
	}
	write_state=0;
	seek(key);
	memcpy(record ,MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer,(LogicalFHBuffer->RecordSize+1));
	if(opmod ==1)
		updateflag = true;
}

void hashfile::write(string& key ,char* record)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="i"||MyFile.openmode=="I")
	{
		err="The file is open to read only!";
		throw err;
	}
	if (key.length()>LogicalFHBuffer->KeySize)
	{
		err="your key size is bigger than the size of the file!";
		throw err;
	}
	int S=strlen(record);
	if (S> LogicalFHBuffer->RecordSize)
	{
		err="The size of the this record is bigger than the general size of a record!";
		throw err;
	}
	char* str1=new char[8];
	strcpy(str1 , key.c_str());
	write_state= 1;
	seek(str1);

	if(write_state == 3)
	{
		int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID, str1);
		if(hashNum == 0)
			hashNum =1;
		helpwrite(hashNum , record);
		if(MyFile.cb.Nr != hashNum)
		{
			MyFile.SeekToBlock(hashNum);
			MyFile.readBlock();
			MyFile.SeekToBlock(hashNum);
			LogicalBuffer->NrOfOverflowedRecs+=1;
			LogicalBuffer->OverflowBlockPtr=LogicalFHBuffer->OverflowAreaStart;
			MyFile.writeBlock();
		}
	}
	else
	{
		err="ERROR! the record is exist.";
		throw err;
	}
	delete []str1;
}

void hashfile::write(char* key , char* record)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="i"||MyFile.openmode=="I")
	{
		err="The file is open to read only!";
		throw err;
	}
	if (strlen(key)>LogicalFHBuffer->KeySize)
	{
		err="your key size is bigger than the size of the file!";
		throw err;
	}
	if (strlen(record)>LogicalFHBuffer->RecordSize)
	{
		err="The size of the this record is bigger than the general size of a record!";
		throw err;
	}
	write_state= 1;
	seek(key);
	if(write_state == 3)
	{
		int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID, key);
		if(hashNum == 0)
			hashNum =1;
		helpwrite(hashNum , record);
		if(MyFile.cb.Nr != hashNum)
		{
			MyFile.SeekToBlock(hashNum);
			MyFile.readBlock();
			MyFile.cb.Nr--;
			LogicalBuffer->NrOfOverflowedRecs+=1;
			LogicalBuffer->OverflowBlockPtr=LogicalFHBuffer->OverflowAreaStart;
			MyFile.writeBlock();
		}
	}
	else
	{
		err="ERROR! the record is exist.";
		throw err;
	}
}

void hashfile::write(int key , char* record)
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	else if(MyFile.openmode=="i"||MyFile.openmode=="I")
	{
		err="The file is open to read only!";
		throw err;
	}
	if (sizeof(key)>LogicalFHBuffer->KeySize)
	{
		err="your key size is bigger than the size of the file!";
		throw err;
	}
	if (strlen(record)>LogicalFHBuffer->RecordSize)
	{
		err="The size of the this record is bigger than the general size of a record!";
		throw err;
	}
	char* str=new char[8];
	strcpy(str ,IntToString(key).c_str());

	write_state= 1;
	seek(str);
	if(write_state == 3)
	{
		int hashNum = hashfunction.HashFunction(LogicalFHBuffer->HashFuncID, str);
		if(hashNum == 0)
			hashNum =1;
		helpwrite(hashNum , record);
		if(MyFile.cb.Nr != hashNum)
		{
			MyFile.SeekToBlock(hashNum);
			MyFile.readBlock();
			MyFile.cb.Nr--;
			LogicalBuffer->NrOfOverflowedRecs+=1;
			LogicalBuffer->OverflowBlockPtr=LogicalFHBuffer->OverflowAreaStart;
			MyFile.writeBlock();
		}
	}
	else
	{
		err="ERROR! the record is exist.";
		throw err;
	}
	delete []str;
}

// check if the record is in block
bool hashfile::Check_If_Key_Is_In_This_Block(int hashnum,char Key[])
{
	rec_loc=0;
	int i=0;
	int kay_1=0;
	bool flag= false;
	if(MyFile.cb.Nr >0)
	{
		int mone=0;
		int tmp=0;

		string s = "";
		string A ="";
		int one = strlen(Key);
		for (int i = 0; i <one; i++)
		{
			s+= Key[i];
		}
		kay_1= atoi(s.c_str());
		for( ; rec_loc< limit; rec_loc+=LogicalFHBuffer->RecordSize)
		{
			int k =rec_loc+LogicalFHBuffer->KeyOffset;

			tmp=0;
			mone=0;

			char* W = new char[LogicalFHBuffer->KeySize];

			int key_size =strlen(Key);

			memcpy(W,MyFile.cb.Buffer.data+rec_loc,LogicalFHBuffer->KeySize);

			if ((*(int*)W)==kay_1)
				//if (R==s)
			{
				flag =true;
				delete[]W;
				return flag;	
			}
			delete[]W;
		}
		return flag;
	}

}

// help function for seek function
void hashfile::helpseek(int hashnum,char Key[])
{
	bool flag= false;
	string err;
	if(MyFile.cb.Nr ==hashnum)
	{
		flag=Check_If_Key_Is_In_This_Block(hashnum,Key);
	}

	while(LogicalBuffer->OverflowBlockPtr!=0 && flag==false)
	{
		MyFile.SeekToBlock(LogicalBuffer->OverflowBlockPtr);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		flag=Check_If_Key_Is_In_This_Block(hashnum,Key);	
	}
	if(flag ==false && write_state== 1 )
		write_state=3;
	if(flag ==true && write_state == 0)
		CurrRecNrInBuffer = rec_loc;
	if(flag==false && write_state==0)
	{
		err="The record is not found!";
		throw err;
	}
	else if(flag==true && write_state==1)
	{
		err="The recoerd is allready exist!";
		throw err;
	}
}

bool hashfile::Check_free_space_In_Block(char* record)
{
	char kay_local;
	int i=LogicalFHBuffer->KeyOffset;
	bool flag=false;


	for( ;i<limit;i+=LogicalFHBuffer->RecordSize)
	{
		if(MyFile.cb.Buffer.data[i]== NULL)
		{
			memcpy(MyFile.cb.Buffer.data+hashfile::LogicalBuffer->NrOfRecsInBlock*hashfile::LogicalFHBuffer->RecordSize ,record,LogicalFHBuffer->RecordSize);
			LBuffChanged=true;
			LHBuffChanged=true;
			LogicalBuffer->NrOfRecsInBlock+=1;
			LogicalFHBuffer->NrOfRecsInFile+=1;
			flush(2);
			flag=true;
			return flag ; 
		}
	}
	return flag;
}
// help function for the write function
void hashfile::helpwrite(int key,char* record)
{

	bool can_write = false; 
	MyFile.SeekToBlock(key);
	MyFile.readBlock();

	MyFile.SeekToBlock(key);

	can_write = Check_free_space_In_Block(record);
	if(can_write == false)
	{
		MyFile.SeekToBlock(LogicalFHBuffer->OverflowAreaStart);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		can_write = Check_free_space_In_Block(record);
	}
	while(can_write == false && LogicalBuffer->OverflowBlockPtr !=0)
	{
		MyFile.SeekToBlock(LogicalBuffer->OverflowBlockPtr);
		MyFile.readBlock();
		MyFile.cb.Nr--;
		can_write = Check_free_space_In_Block(record);
	}

	if(LogicalBuffer->OverflowBlockPtr ==0)
	{
		if(LogicalFHBuffer->FileSize == MyFile.cb.Nr+1)
		{
			string err="Error! The File is full!";
			throw err;
		}
	}
}

void hashfile::Del_rec_Casing(char* key)
{
	char* rec=new char[LogicalFHBuffer->RecordSize];
	read(key,rec,1);
	Delrec();
	if(MyFile.cb.Nr<LogicalBuffer->OverflowBlockPtr)
	{
		Press_Bloak(key);
	}
	//Press_Block_OV();
	updateflag=false;
	//delete []rec;
}

void hashfile::Delrec(void)
{
	char* record=new char[LogicalFHBuffer->RecordSize];
	for(int i=0 ; i< LogicalFHBuffer->RecordSize ;i++)
		record[i]='\0';
	memcpy(MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer , record , LogicalFHBuffer->RecordSize);
	LBuffChanged=true;
	LHBuffChanged=true;
	LogicalBuffer->NrOfRecsInBlock-=1;
	LogicalFHBuffer->NrOfRecsInFile-=1;
	flush(2);
	delete []record;
}

void hashfile::Press_Bloak(char* key)
{
	int Key_rec;
	MyFile.cb.Nr--;
	int delrec=(hashfile::LogicalBuffer->NrOfRecsInBlock-1)*hashfile::LogicalFHBuffer->RecordSize;
	if(LogicalBuffer->NrOfOverflowedRecs ==0)
	{
		memcpy(MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer, MyFile.cb.Buffer.data+(hashfile::LogicalBuffer->NrOfRecsInBlock-1)*hashfile::LogicalFHBuffer->RecordSize,LogicalFHBuffer->RecordSize);

		CurrRecNrInBuffer=delrec;
		Delrec();
	}
	while(LogicalBuffer->OverflowBlockPtr!=0)
	{
		Key_rec=Serch_key_by_hash(MyFile.cb.Nr);
		if(Key_rec !=0)
		{
			char* G=new char[8];
			char* tmp=new char[LogicalFHBuffer->RecordSize];
			read(Key_rec,tmp,0);
			strcpy(G,IntToString(Key_rec).c_str());
			Del_rec_Casing(G);
			write(Key_rec,tmp);
			delete [] tmp; delete []G;
		}
	}	
}

void hashfile::Press_Block_OV()
{
	char* tmp=new char [LogicalFHBuffer->RecordSize];
	bool flag=false;
	MyFile.SeekToBlock(LogicalFHBuffer->OverflowAreaStart);
	MyFile.readBlock();
	MyFile.cb.Nr--;
	int i=LogicalFHBuffer->KeyOffset;
	while(flag ==false)
	{
		int i=LogicalFHBuffer->KeyOffset;
		for( ;i<limit;i+=LogicalFHBuffer->RecordSize)
		{	
			int s= LogicalBuffer->NrOfRecsInBlock * LogicalFHBuffer->RecordSize;
			if((MyFile.cb.Buffer.data[i]==NULL)&&(i<s))
			{
				int cb_block=MyFile.cb.Nr;
				while(flag==false )
				{
					MyFile.SeekToBlock(LogicalBuffer->OverflowBlockPtr);
					MyFile.readBlock();
					if(limit != (LogicalBuffer->NrOfRecsInBlock * LogicalFHBuffer->RecordSize))
					{
						memcpy(tmp, hashfile::MyFile.cb.Buffer.data+(hashfile::LogicalBuffer->NrOfRecsInBlock-1)*(hashfile::LogicalFHBuffer->RecordSize),LogicalFHBuffer->RecordSize);
						CurrRecNrInBuffer= (hashfile::LogicalBuffer->NrOfRecsInBlock-1)*hashfile::LogicalFHBuffer->RecordSize;
						Delrec();
						flag=true;
					}
				}
				MyFile.SeekToBlock(cb_block);
				MyFile.readBlock();
				MyFile.cb.Nr--;
				memcpy(hashfile::MyFile.cb.Buffer.data+i,tmp,LogicalFHBuffer->RecordSize);
				LBuffChanged=true;
				LHBuffChanged=true;
				flush(2);
				break;
			}
		}
		MyFile.SeekToBlock(LogicalBuffer->OverflowBlockPtr);
		MyFile.readBlock();
		MyFile.cb.Nr--;
	}
	delete []tmp;
}

int hashfile::Serch_key_by_hash(int key)
{
	int Hash_num1 =0;
	int key_loc=0,key_rec=0; string F="";
	MyFile.SeekToBlock(LogicalBuffer->OverflowBlockPtr);
	MyFile.readBlock();
	for( ; key_loc< limit; key_loc+=LogicalFHBuffer->RecordSize)
	{
		F="";
		for(int g=0 ; g<LogicalFHBuffer->KeySize ;g++)
		{
			F+=MyFile.cb.Buffer.data[key_loc+g];
		}
		key_rec =atoi(F.c_str());
		Hash_num1 =hashfunction.HashFunction(LogicalFHBuffer->HashFuncID, key_rec);
		if(Hash_num1 == key)
		{
			return key_rec;
		}
	}
	return 0;
}

void hashfile::Update(char* rec)
{
	char* Same_key=new char[LogicalFHBuffer->KeySize];
	char* rec_key= new char[LogicalFHBuffer->KeySize];
	memcpy(Same_key,hashfile::MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer,LogicalFHBuffer->KeySize-1);
	memcpy(rec_key,rec,LogicalFHBuffer->KeySize-1);
	for (int u=0; u<LogicalFHBuffer->KeySize-1; u++)
	{
		if (Same_key[u] != rec_key[u])
		{
			delete []Same_key; delete []rec_key;
			string err="you can't change record with different key!";
			throw err;
		}
	}

	memcpy(hashfile::MyFile.cb.Buffer.data+hashfile::CurrRecNrInBuffer,rec,LogicalFHBuffer->RecordSize);
	LBuffChanged=true;
	LHBuffChanged=true;
	flush(2);
	updateflag=false;
	delete []Same_key; delete []rec_key;
}

void hashfile::updateoff(void)
{
	string err;
	if(updateflag==false)
	{
		err="The file is not in locking mode!";
		throw err;
	}
	else if(MyFile.openmode=="i"||MyFile.openmode=="I"||MyFile.openmode=="o"||MyFile.openmode=="O")
	{
		err="The file is not in i/o mode!";
		throw err;
	}
	else
		updateflag=false;
}

float hashfile::load_factor()
{
	string err;
	if (updateflag==true)
	{
		err="you can't do this operation while the file is in lock mode!";
		throw err;
	}
	if(MyFile.opened==false)
	{
		err="The file is closed!";
		throw err;
	}
	float A=0,Lowest_Hahs=1; int x =0;

	for(int i=LogicalFHBuffer->OverflowAreaStart ; i<MyFile.FileSize ; i++)
	{
		MyFile.SeekToBlock(i);
		MyFile.readBlock();
		x+=LogicalBuffer->NrOfRecsInBlock;
	}
	A= ((float)x /(float)((float)LogicalFHBuffer->NrOfRecsInFile));
	
	return A;
}

char* hashfile::filename()
{
	return LogicalFHBuffer->FileName;
}

char* hashfile::OwnerName()
{
	return LogicalFHBuffer->OwnerName;
}

char* hashfile::CreationDate()
{
	return LogicalFHBuffer->CreationDate;
}

int hashfile::FileSize()
{
	return LogicalFHBuffer->FileSize;
}

int hashfile::RecordSize()
{
	return LogicalFHBuffer->RecordSize;
}

int hashfile::HashFuncID()
{
	return LogicalFHBuffer->HashFuncID;
}

int hashfile::NrOfRecsInFile()
{
	return LogicalFHBuffer->NrOfRecsInFile;
}

int hashfile::OverflowAreaStart()
{
	return LogicalFHBuffer->OverflowAreaStart;
}