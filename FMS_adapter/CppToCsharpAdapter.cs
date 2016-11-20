using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FMS_adapter
{
    class CppToCsharpAdapter
    {
        const string dllPath = "FMS_DLL.dll";
        [DllImport(dllPath)]
        public static extern bool is_open(IntPtr p);
        [DllImport(dllPath)]
        public static extern string open_mode(IntPtr p);
        [DllImport(dllPath)]
        public static extern IntPtr MakeHashFileObject();
        [DllImport(dllPath)]
        public static extern void DeleteHashFileObject(ref IntPtr p);
 
        public static string GetLastErrorMessage(IntPtr p)
        {
            IntPtr ptr = GetLastErrorMessageDll(p);
            string str = Marshal.PtrToStringAnsi(ptr);
            return str;
        }

        [DllImport(dllPath, EntryPoint = "GetLastErrorMessage")]
        public static extern IntPtr GetLastErrorMessageDll(IntPtr p);
        [DllImport(dllPath)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static extern string int_to_string(IntPtr p,int a);
        [DllImport(dllPath)]
        public static extern void hcreate(IntPtr p, string filenam="", string usernam="", int longrecord=0,string path="" , int sizefile=0 ,
	    int keyloc=0 ,string type="I" , int keylong=4, int hashfuncid=1);
        [DllImport(dllPath)]
        public static extern void hdelete(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern void hopen(IntPtr THIS, string fileName, string userName,
        string path = "", string openmode = "I");
        [DllImport(dllPath)]
        public static extern void hclose(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern void flush(IntPtr THIS, int num);
        [DllImport(dllPath)]
        public static extern void read(IntPtr THIS, int key, IntPtr buffer, int update = 0);
        [DllImport(dllPath, EntryPoint = "readByStringKey")]
        public static extern void read(IntPtr THIS, string key, IntPtr buffer, int update = 0);
        [DllImport(dllPath)]
        public static extern void write(IntPtr THIS, int key, IntPtr buffer);
        [DllImport(dllPath, EntryPoint = "writeByStringKey")]
        public static extern void write(IntPtr THIS, string key, IntPtr buffer);
        [DllImport(dllPath)]
        public static extern bool Check_If_Key_Is_In_This_Block(IntPtr THIS,int hashnum,char[] Key);
        [DllImport(dllPath)]
        public static extern void helpseek(IntPtr THIS,int hashnum,char[] Key);
        [DllImport(dllPath)]
        public static extern bool Check_free_space_In_Block(IntPtr THIS, string record);
        [DllImport(dllPath)]
        public static extern void helpwrite(IntPtr THIS, int key, string record);
        [DllImport(dllPath)]
        public static extern void Del_rec_Casing(IntPtr THIS, string key);
        [DllImport(dllPath)]
        public static extern void Delrec(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern void Press_Bloak(IntPtr THIS, string Key);
        [DllImport(dllPath)]
        public static extern void Press_Block_OV(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int Serch_key_by_hash(IntPtr THIS,int num);
        [DllImport(dllPath)]
        public static extern void Update(IntPtr THIS, IntPtr rec);
        [DllImport(dllPath)]
        public static extern void updateoff(IntPtr THIS);
        [DllImport(dllPath)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static extern string GetFileInfo(IntPtr THIS);
        [DllImport(dllPath)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static extern string GetBlockInfo(IntPtr THIS, int blockNumber);
        [DllImport(dllPath)]
        public static extern int HashIntSimulation(IntPtr THIS, int[] arr, int size, int fileSize);
        [DllImport(dllPath)]
        public static extern int HashStringSimulation(IntPtr THIS, string[] arr, int size, int fileSize);
        [DllImport(dllPath)]
        public static extern float load_factor(IntPtr THIS);
        public static string filename(IntPtr p)
        {
            IntPtr ptr = filenameDll(p);
            string str = Marshal.PtrToStringAnsi(ptr);
            return str;
        }
        [DllImport(dllPath, EntryPoint = "filename")]
        public static extern IntPtr filenameDll(IntPtr THIS);
        public static string OwnerName(IntPtr p)
        {
            IntPtr ptr = OwnerNameDll(p);
            string str = Marshal.PtrToStringAnsi(ptr);
            return str;
        }
        [DllImport(dllPath, EntryPoint = "OwnerName")]
        public static extern IntPtr OwnerNameDll(IntPtr p);
        public static string CreationDate(IntPtr p)
        {
            IntPtr ptr = CreationDateDll(p);
            string str = Marshal.PtrToStringAnsi(ptr);
            return str;
        }
        [DllImport(dllPath, EntryPoint = "CreationDate")]
        public static extern IntPtr CreationDateDll(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int FileSize(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int RecordSize(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int HashFuncID(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int NrOfRecsInFile(IntPtr THIS);
        [DllImport(dllPath)]
        public static extern int OverflowAreaStart(IntPtr THIS);
    };
}
