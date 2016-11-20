#pragma once
#include <iostream>
#include <string>
#include<sstream>
#include <list>
#include <fstream>
#include"PhysicalBlockclass.h"
#include"PhysicalFileClass.h"
#include "CurrBlock.h"
#include"hashfile.h"
#include"HashValue.h"
#include"LogicalBlock.h"
#include"LogicalFileHeader.h"
#include <conio.h>
#include <windows.h>
using namespace std;

// class for each student from the text file
class Student
{
public:
	string fname;
	string lname;
	int grade;
	string cours_name;
	int id;
	int reg_nr;
	Student(){};
	Student(string f="",string l="",string cn="",int g=0,int i=0,int rn=0)
	{
		fname=f;
		lname=l;
		grade=g;
		id=i;
		cours_name=cn;
		reg_nr=rn;
	}

};

void insertToBlock(list<Student>sli ,hashfile &myFiles);

//list of the all student structure of its fields
list<Student>tmp()
{
	list<Student>sl;
	string str;
	ifstream infile;
	infile.open ("studcourses.txt");
	while(!infile.eof()) // To get you all the lines.
	{
		int tmp1;
		getline(infile,str); // Saves the line in STRING.
		//cout<<STRING; // Prints our STRING.
		string fname="";
		string lname="";
		int grade=0;
		string cours_name="";
		int id=0;
		int reg_nr=0;
		list<string> tmp;
		int x= str.find(',');
		id = atoi(str.substr(0,4).c_str());
		int x2 =str.find(',',x+1);
		tmp1=(x2-x);
		reg_nr= atoi(str.substr(x+1,tmp1).c_str());
		x = str.find(',',x2+1);
		tmp1 =(x-x2);
		lname= str.substr(x2+1,tmp1-1);
		x2 =str.find(',',x+1);
		tmp1= (x2-x);
		fname =str.substr(x+1,tmp1-1);
		x = str.find(',',x2+1);
		tmp1 =(x-x2);
		cours_name = str.substr(x2+1,tmp1-1);
		x2 =str.find(',',x+1);
		tmp1= (x2-x);
		grade = atoi(str.substr(x+1,tmp1-1).c_str());
		Student t(fname,lname,cours_name,grade,id,reg_nr);
		sl.push_back(t);			
	}
	infile.close();
	return sl;
}

void main()
{

	list<Student>student_list;
	student_list=tmp();
	int a = 0;
	PhysicalFile File;
	hashfile MyFiles;

	while(true)
	{
		try
		{
			cout<<"\t\t ****MAIN**** \n";
			cout<<"1. Create logical File. \n";
			cout<<"2. Open file \n";
			cout<<"3. Close file\n";
			cout<<"4. Delete file\n";
			cout<<"5. Read data from a specific Block \n";
			cout<<"6. Write data to a specific Block \n";
			cout<<"7. insert the text file in hash file \n";
			cout<<"8. Write a record in file\n";
			cout<<"9. Read a record from  file \n";
			cout<<"10 New Test File\n";
			cout<<"11 Open Test File Test\n";
			cout<<"12. Create 10 new files for hash testing\n";
			cout<<"13. Get the best Hash function from all the given 10\n";
			cout<<"14. Delete record from the file\n";
			cout<<"15. Update record into the file\n";
			cout<<"16. unlock of update mode.\n";
			cout<<"17. EXIT\n";
			cin>>a;
			system("cls");
			switch(a)
			{
			case 1:
				{
					string filename="" , path="", username="",opmode="";
					int siz=0,choos=0,keyloc=0;
					unsigned int recl=0,keyl=0,hushfuid=2; 
					cout<<"Please enter file name: ";
					cin>>filename;
					cout<<"\nPlease enter the user name: ";
					cin>>username;
					cout<<"\nPlease enter the record's length: ";
					cin>>recl;
					cout << "\nPlease enter number of blocks (size file): ";
					cin >> siz;
					cout<<"\nPlease enter the key location: ";
					cin>>keyloc;
					cout<<"\nPlease enter your open mode (I or O or IO): ";
					cin>>opmode;
					cout<<"\nPlease enter the length of your key: ";
					cin>>keyl;
					cout << "\nDo you want to choose a diferent path? (1-NO , 2-YES):";
					cin >> choos;
					cout<<"Enter the code of the hash function. \n";
					cin>>hushfuid;
					if(choos==2)
					{
						cout << "Please enter your path\n";
						cin>> path;
					}
					MyFiles.hcreate(filename,username,recl,path,siz,keyloc,opmode,keyl,hushfuid);
					system("cls");
					break;
				}
			case 2:
				{
					int x;
					string filename="" , path="" , opmode="" , username="";
					cout<<" Please enter the file name\n";
					cin>>filename;
					cout<<" Please enter the user name\n";
					cin>>username;
					cout <<"Please enter open mode (I,O,IO)\n";
					cin>>opmode;
					cout << "Search file in this directory? (1-YES , 2-NO)";
					cin>>x;
					if(x==2)
					{
						cout << "PLease enter your path\n";
						cin>>path;
					}
					MyFiles.hopen(filename, username , path , opmode);
					system("cls");
					break;

				}
			case 3:
				{
					MyFiles.hclose();
					cout<<"The close done succesfully.\n";
					system ("pause");
					system("cls");
					break;
				}
			case 4:
				{
					MyFiles.hdelete();
					system("cls");
					break;
				}
			case 5:
				{
					int blocknum;
					cout<<"Please enter the block number\n";
					cin>>blocknum;
					MyFiles.MyFile.SeekToBlock(blocknum);
					MyFiles.MyFile.readBlock();
					string my_string(MyFiles.MyFile.cb.Buffer.data);
					cout<<"data in block number "<< blocknum<< " is: "<<my_string <<endl;
					system ("pause");
					break;

				}
			case 6:
				{
					unsigned int nr=0;
					string writ="";
					cout<<"Please enter the block number which you want to right into. \n";
					cin>>nr;
					cout<<"Now, Please enter your data.\n";
					cin>>writ;
					strcpy(MyFiles.MyFile.cb.Buffer.data ,writ.c_str()); 
					MyFiles.MyFile.SeekToBlock(nr);
					MyFiles.MyFile.writeBlock();
					MyFiles.LBuffChanged==true;
					break;

				}
			case 7:
				{
					insertToBlock(student_list, MyFiles);
					system("pause");
					system("cls");
					break;
				}
			case 8:
				{
					int choise, tmp2;
					string tmp1,record;
					char* tmp=new char [MyFiles.LogicalFHBuffer->KeySize];
					char* Record=new char [MyFiles.LogicalFHBuffer->RecordSize];
					cout<<"Please enter your record: ";
					cin>>record;
					strcpy(Record,record.c_str());
					cout<<"Please enter the type of your key:\n1-int\n2-c string\n3-string\n";
					cin>>choise;
					cout<<"Please enter your key:";
					
					switch (choise)
					{
					case 1:
						{
							cin>>tmp2;
							MyFiles.write(tmp2,Record);
							break;
						}
					case 2:
						{
							cin>>tmp;
							MyFiles.write(tmp,Record);
							break;
						}
					case 3:
						{
							cin>>tmp1;
							MyFiles.write(tmp1,Record);
							break;
						}
					}
					break;
				}
			case 9:
				{
					int Key_rec=0;
					char* F= new char[MyFiles.LogicalFHBuffer->RecordSize] ;
					cout<<"Enter The Key number of your record! \n";
					cin>> Key_rec;
					MyFiles.read(Key_rec , F,0);
					cout<<" The record is: \n";
					cout<<F<<endl;;
					break;
				}
			case 10:
				{
					MyFiles.hcreate("mos1","eli",70,"",23,0,"io",6,1);
					system("cls");
					break;
				}
			case 11:
				{
					MyFiles.hopen("mos1", "eli" , "" , "io");
					system("pause");
					system("cls");
					break;
				}
			case 12:
				{
					string FILE_NAME_EXPORT="";
					string Owner="";
					int Record_lenght=0;
					int BlockNR=0;
					cout << "Please enter file name.\n"
						<<"at the end of the proccess 10 files will be created!\n"
						<< "each one using a different hash function.\n"
						<<"the program will show you the best one\n";
					cin  >> FILE_NAME_EXPORT;
					string tmp= FILE_NAME_EXPORT;
					cout << "Pleae enter owner name\n";
					cin >> Owner;
					cout << "Pleae enter record lenght\n";
					cin >>Record_lenght;
					cout << "Pleae enter number of blocks\n";
					cin>>BlockNR;
					for(int i=0;i<10;i++)
					{

						FILE_NAME_EXPORT = tmp;
						FILE_NAME_EXPORT+="_FILE_NUMBER_";FILE_NAME_EXPORT+=MyFiles.IntToString(i);	

						MyFiles.hcreate(FILE_NAME_EXPORT,Owner,Record_lenght,"",BlockNR,0,"io",6,i);
						MyFiles.hopen(FILE_NAME_EXPORT, Owner, "" ,"io"); 
						insertToBlock(student_list,MyFiles);
						MyFiles.hclose();
					}
					system("pause");
					system("cls");
					break;
				}
			case 13:
				{
					int x=0; string FILE_NAME_EXPORT="",F="",owner="";
					cout<<"Please enter the name of the files. \n ";
					cin>>F;
					cout<<"Enter the owner of the files. \n";
					cin>>owner;
					float Hashes[10]={}; float A=0,Lowest_Hahs=1;
					for(int j=0 ; j<10 ; j++)
					{
						FILE_NAME_EXPORT = F;
						FILE_NAME_EXPORT+="_FILE_NUMBER_";FILE_NAME_EXPORT+=MyFiles.IntToString(j);
						MyFiles.hopen(FILE_NAME_EXPORT, owner, "" ,"io");
						for(int i=MyFiles.LogicalFHBuffer->OverflowAreaStart ; i< MyFiles.MyFile.FileSize ; i++)
						{
							MyFiles.MyFile.SeekToBlock(i);
							MyFiles.MyFile.readBlock();
							x+=MyFiles.LogicalBuffer->NrOfRecsInBlock;
						}
						A= ((float)x /(float)((float)MyFiles.LogicalFHBuffer->NrOfRecsInFile));
						Hashes[j]= A;
						x=0;
						MyFiles.hclose();
					}
					for(int E=0 ; E<10 ;E++)
					{
						if(Hashes[E] <= Lowest_Hahs)
						{
							Lowest_Hahs=Hashes[E];
							x=E;
						}

					}
					cout<<" The Best hash function is : " <<x<<"  "<<Lowest_Hahs<<endl;	
					system("pause");
					system("cls");
					break;
				}
			case 14:
				{
					string S=""; char *rec= new char[S.length()];
					cout<<"Please enter the key of the record.c_str\n";
					cin>>S;
					strcpy(rec , S.c_str());
					MyFiles.Del_rec_Casing(rec);
					cout<<" The record deleted Successfully !!!\n";
					system("cls");
					break;
				}
			case 15:
				{
					string S="",R=""; char *rec= new char[S.length()]; char*rec2=new char[R.length()];
					cout<<"Please enter the key of the record\n";
					cin>>S;
					strcpy(rec , S.c_str());
					cout<<"Please enter the updated record.\n(note that the key of your record is the same as you entered before.)\n";
					cin>>R;
					strcpy(rec2, R.c_str());
					MyFiles.read(S,rec,1);
					MyFiles.Update(rec2);
					cout<<"The update has done successfully!\n";
					system("pause");
					system("cls");
					break;		
				}
			case 16:
				{
					MyFiles.updateoff();
					system("cls");
					break;
				}
			case 17:
				{
					system("cls");
					cout << "Byebye.";
					for(int i=0;i<4;++i)
					{
						Sleep(500);
						cout << ".";
					}
					exit(0);
				}
			default:
				{
					cout<<"ERROR !\n";
					system("pause");
					system("cls");
					break;
				}
			}
		}

		catch(exception& exp)
		{
			cout<<"\n"<<exp.what()<<endl;
			system("pause");
			system("cls");
		}

	}
}

//insert all of the txt file into the hash file (write in file.hash)
//הופך את הרשומה ל-string ואז מוצא את המפתח ומכניס את הרשומה + המפתח 
void insertToBlock(list<Student>sli ,hashfile &myFiles)
{
	int A=0,a1=0,c=0,i=0;
	int longrec[290];
	string S="",T="";
	char* str="";
	list<Student>::iterator G;
	int mone = 0;
	for(G=sli.begin() ; G != sli.end() ; G++)
	{
		mone++;
		if(mone==124)
		{
			cout<<"";
		}
		S="";
		T="";
		A=(*G).id;
		a1=(*G).reg_nr;
		T+=myFiles.IntToString(A);
		T+=myFiles.IntToString(a1);
		S+=myFiles.IntToString(A);
		S+=myFiles.IntToString(a1);
		S+=(*G).fname;
		S+=(*G).lname;
		S+=(*G).cours_name;
		S+=myFiles.IntToString((*G).grade);
		c=sizeof(S);
		longrec[i+1]=c;  i++;
		char* rec = new char[myFiles.LogicalFHBuffer->RecordSize];
		strcpy(rec , S.c_str());
		myFiles.write(T,rec);
	}
	cout<<"number of record "<<myFiles.LogicalFHBuffer->NrOfRecsInFile<<endl<<endl;
}
