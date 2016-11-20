#include "CurrBlock.h";
#include "hashfile.h";
#include "HashValue.h";
#include "LogicalBlock.h";
#include "LogicalFileHeader.h";
#include "PhysicalBlockclass.h";
#include "PhysicalFileClass.h";

extern "C"
{
	__declspec(dllexport) void* __stdcall MakeHashFileObject()
	{
		return new hashfile();
	}
	__declspec(dllexport) void __stdcall DeleteHashFileObject(hashfile*& THIS)
	{
		if(THIS != NULL)
			delete THIS;
		THIS = NULL;
	}
	__declspec(dllexport) const char* __stdcall GetLastErrorMessage(hashfile* THIS)
	{
		const char* str = THIS->GetLastErrorMessage().c_str();
		return str;
	}
	__declspec(dllexport) bool __stdcall is_open(hashfile* THIS)
	{
		try
		{
			THIS->is_open();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) string __stdcall open_mode(hashfile* THIS)
	{
		try
		{
			string str = THIS->open_mode();
			return str;
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) const char* __stdcall filename(hashfile* THIS)
	{
		try
		{
			return THIS->filename();
			 
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) const char* __stdcall OwnerName(hashfile* THIS)
	{
		try
		{
			return THIS->OwnerName();
			
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) const char* __stdcall CreationDate(hashfile* THIS)
	{
		try
		{
			return THIS->CreationDate();
		
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}

	__declspec(dllexport) int __stdcall FileSize(hashfile* THIS)
	{
		try
		{
			
			return THIS->FileSize();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) int __stdcall RecordSize(hashfile* THIS)
	{
		try
		{
			
			return THIS->RecordSize();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) int __stdcall HashFuncID(hashfile* THIS)
	{
		try
		{
			
			return THIS->HashFuncID();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) int __stdcall NrOfRecsInFile(hashfile* THIS)
	{
		try
		{
			
			return THIS->NrOfRecsInFile();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) int __stdcall OverflowAreaStart(hashfile* THIS)
	{
		try
		{
			
			return THIS->OverflowAreaStart();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	
	__declspec(dllexport) void __stdcall hcreate(hashfile* THIS,char* filenam, char* usernam,unsigned int longrecord, char* path,unsigned int sizefile,
		unsigned int keyloc,char* type,unsigned int keylong, unsigned int hashfuncid)
	{
		try
		{
			THIS->hcreate(filenam,usernam,longrecord,path,sizefile,keyloc,type,keylong,hashfuncid);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall hdelete(hashfile* THIS)
	{
		try
		{
			THIS->hdelete();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall hopen(hashfile* THIS,char* filename , char* usernam , char* path , char* openmode)
	{
		try
		{
			THIS->hopen(filename,usernam,path,openmode);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall hclose(hashfile* THIS)
	{
		try
		{
			THIS->hclose();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void  __stdcall flush(hashfile* THIS, int num)
	{
		try
		{
			THIS->flush(num);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall seek_with_char_star(hashfile* THIS,char *Key)
	{
		try
		{
			THIS->seek(Key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall seek_with_int(hashfile* THIS,int Key)
	{
		try
		{
			THIS->seek(Key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall  read(hashfile* THIS,int key, char* buffer ,int update)
	{
		try
		{
			THIS->read(key,buffer,update);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall  readByStringKey(hashfile* THIS,char* key, char* buffer ,int update)
	{
		try
		{
			THIS->read(key,buffer,update);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall  write(hashfile* THIS,int key , char* buffer)
	{
		try
		{
			THIS->write(key,buffer);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall  writeByStringKey(hashfile* THIS, char* key , char* buffer)
	{
		try
		{
			THIS->write(key,buffer);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) bool __stdcall Check_If_Key_Is_In_This_Block(hashfile* THIS,int hashnum,char Key[])
	{
		try
		{
			THIS->Check_If_Key_Is_In_This_Block(hashnum,Key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall helpseek(hashfile* THIS,int hashnum,char Key[])
	{
		try
		{
			THIS->helpseek(hashnum,Key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) bool __stdcall Check_free_space_In_Block(hashfile* THIS,char* record)
	{
		try
		{
			THIS->Check_free_space_In_Block(record);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall helpwrite(hashfile* THIS,int key,char* record)
	{
		try
		{
			THIS->helpwrite(key,record);
		}
		catch(string  ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall Del_rec_Casing(hashfile* THIS,char* key)
	{
		try
		{
			THIS->Del_rec_Casing(key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall Delrec(hashfile* THIS)
	{
		try
		{
			THIS->Delrec();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall Press_Bloak(hashfile* THIS, char * Key)
	{
		try
		{
			THIS->Press_Bloak(Key);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall Press_Block_OV(hashfile* THIS)
	{
		try
		{
			THIS->Press_Block_OV();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) int  __stdcall Serch_key_by_hash(hashfile* THIS,int num)
	{
		try
		{
			THIS->Serch_key_by_hash(num);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall Update(hashfile* THIS,char* rec)
	{
		try
		{
			THIS->Update(rec);
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) void __stdcall updateoff(hashfile* THIS)
	{
		try
		{
			THIS->updateoff();
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}
	}
	__declspec(dllexport) float  __stdcall load_factor(hashfile* THIS)
	{
		try
		{
			float A = THIS->load_factor();
			return A;
		}
		catch(string ex)
		{
			THIS->SetLastErrorMessage(ex);
			throw ex;
		}

	}
}
	

