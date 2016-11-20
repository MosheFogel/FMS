#pragma once
class LogicalBlock
{
public:
	public:
	unsigned int BlockNr;
	unsigned int NrOfOverflowedRecs;
	unsigned int OverflowBlockPtr;
	unsigned char NrOfRecsInBlock;
	char filler [11];//fields.
	char data[1000];
	LogicalBlock(void);
	~LogicalBlock(void);
};

