#pragma once
class LogicalFileHeader
{
public:
	unsigned int BlockNr;
	char FileName[12];
	char OwnerName[10];
	unsigned int FileSize;
	char CreationDate[10];
	unsigned int RecordSize;
	int HashFuncID;
	unsigned int NrOfRecsInFile;
	unsigned int KeyOffset;
	char KeyType[2];
	unsigned int KeySize;
	unsigned int OverflowAreaPtr;
	unsigned int OverflowAreaStart;
	char Filler[946];
	
	LogicalFileHeader(void);
	~LogicalFileHeader(void);
};

