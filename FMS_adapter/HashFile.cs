using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FMS_adapter
{
    public static class HashFileStat
    {
        public static HashFile HFStatic;
        public static bool is_opened;//indicates if there's an opened file. 
        static HashFileStat()
        {
            HFStatic = new HashFile();
            is_opened = false;
        }
    };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class StudCourseI
    {
        public int Key;
        public int StudID;
        public int RegNr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string FamilyName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string FirstName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 58)]
        public string CourseName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Grade;
        /*************************************************
	* FUNCTION:
	* DigitCount 
	* PARAMETERS:
	* int - registration number from StudCourse struct . 
	* Return Value:
	* int - registration number' amount of digits. 
	* MEANING:
	* This function calculates how much digits in registration number. Service function for ConvToStructI && ConvToStructC.
	**************************************************/
        public double DigitCount(int regNr)
        {
            int count = 0;
            while (regNr != 0)
            {
                regNr /= 10;
                count++;
            }
            return (double)count;
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class StudCourseC
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Key;
        public int StudID;
        public int RegNr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string FamilyName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string FirstName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 58)]
        public string CourseName;
         [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Grade;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class StudupdateI
    {
        public int Key;
        public int StudID;
        public int RegNr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 58)]
        public string CourseName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Grade;
        /*************************************************
	* FUNCTION:
	* DigitCount 
	* PARAMETERS:
	* int - registration number from StudCourse struct . 
	* Return Value:
	* int - registration number' amount of digits. 
	* MEANING:
	* This function calculates how much digits in registration number. Service function for ConvToStructI && ConvToStructC.
	**************************************************/
        public double DigitCount(int regNr)
        {
            int count = 0;
            while (regNr != 0)
            {
                regNr /= 10;
                count++;
            }
            return (double)count;
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class StudupdateC
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Key;
        public int StudID;
        public int RegNr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 58)]
        public string CourseName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Grade;
    }

    public class HashFile
    {
        IntPtr my_hash_file_pointer;


        public HashFile()
        {
            my_hash_file_pointer = CppToCsharpAdapter.MakeHashFileObject();
        }
        ~HashFile()
        {
            CppToCsharpAdapter.DeleteHashFileObject(ref my_hash_file_pointer);
        }
        public bool is_open()
        {
            try
            {
               return  CppToCsharpAdapter.is_open(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
        public string open_mode()
        {
            try
            {
               return CppToCsharpAdapter.open_mode(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
        public string IntToString(int a)
        {
            try
            {
                return CppToCsharpAdapter.int_to_string(my_hash_file_pointer, a);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message+ex);
            }
            catch
            {
                throw;
            }
            
        }
        public void hcreate(string filenam = "", string usernam = "", int longrecord = 0, string path = "", int sizefile = 0,
        int keyloc = 0, string type = "I", int keylong = 4, int hashfuncid = 1)
        {
            try
            {
                CppToCsharpAdapter.hcreate(my_hash_file_pointer, filenam, usernam, longrecord, path, sizefile, keyloc, type, keylong, hashfuncid);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
        public void hopen(string filename, string usernam, string path, string openmode)
        {
            try
            {
                CppToCsharpAdapter.hopen(my_hash_file_pointer, filename, usernam, path, openmode);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
        public void hclose()
        {
             try
            {
                CppToCsharpAdapter.hclose(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
             catch
             {
                 throw;
             }
            
        }
        public void hdelete()
        {
             try
            {
                CppToCsharpAdapter.hdelete(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
             catch
             {
                 throw;
             }
           
        }
        
        public Object Read(string key, Object obj, int update = 0)
        {
            try
            {

                IntPtr buffer;
                buffer = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));

                CppToCsharpAdapter.read(my_hash_file_pointer, key, buffer,update);
                Marshal.PtrToStructure(buffer, obj);

                Marshal.FreeHGlobal(buffer);

                return obj;
            }
            catch (SEHException)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
           
        }
        public Object Read(int key, Object obj, int update = 0)
        {
            try
            {

                IntPtr buffer;
                buffer = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));

                CppToCsharpAdapter.read(my_hash_file_pointer, key, buffer,update);
                Marshal.PtrToStructure(buffer, obj);

                //Marshal.FreeHGlobal(buffer);

                return obj;
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
          
        }

        public void Write(string key, Object obj)
        {
            try
            {
                IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));
                Marshal.StructureToPtr(obj, buffer, true);
                
                CppToCsharpAdapter.write(my_hash_file_pointer, key, buffer);

                Marshal.FreeHGlobal(buffer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
          
        }
        public void Write(int key, Object obj)
        {
            try
            {
                IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));
                Marshal.StructureToPtr(obj, buffer, true);

                CppToCsharpAdapter.write(my_hash_file_pointer, key, buffer);

                Marshal.FreeHGlobal(buffer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
          
        }
        
        public bool Check_If_Key_Is_In_This_Block(int hashnum,char[] Key)
        {
             try
            {
               return  CppToCsharpAdapter.Check_If_Key_Is_In_This_Block(my_hash_file_pointer, hashnum, Key);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
             catch
             {
                 throw;
             }
             
        }
        public void Del_rec_Casing(string Key)
        {
            try
            {
              CppToCsharpAdapter.Del_rec_Casing(my_hash_file_pointer,Key);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
        public void Delrec()
        {
            try
            {
                CppToCsharpAdapter.Delrec(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
         
        }
        public void Update(Object obj)
        {
            try
            {
                IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));
                Marshal.StructureToPtr(obj, buffer, true);

                CppToCsharpAdapter.Update(my_hash_file_pointer, buffer);

                Marshal.FreeHGlobal(buffer);

            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
          
        }
        public void updateoff()
        {
            try
            {
                CppToCsharpAdapter.updateoff(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
         
        }
        public string GetFileInfo()
        {
            try
            {
                string str = CppToCsharpAdapter.GetFileInfo(my_hash_file_pointer);
                return str;
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
         
        }
        public string GetBlockInfo(int blockNumber)
        {
            try
            {
                return CppToCsharpAdapter.GetBlockInfo(my_hash_file_pointer, blockNumber);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
           
        }
        public int HashIntSimulation(int[] arr, int fileSize)
        {
            try
            {
                return CppToCsharpAdapter.HashIntSimulation(my_hash_file_pointer, arr, arr.Length, fileSize);
            }
            catch (SEHException)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
           
        }
        public int HashStringSimulation(string[] arr, int fileSize)
        {
            try
            {
                return CppToCsharpAdapter.HashStringSimulation(my_hash_file_pointer, arr, arr.Length, fileSize);
            }
            catch (SEHException)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
            
        }
        public float load_factor()
        {
            try
            {
                float str = CppToCsharpAdapter.load_factor(my_hash_file_pointer);
                return str;
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public string filename()
        {
            try
            {
                string str = CppToCsharpAdapter.filename(my_hash_file_pointer);
                return str;
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public string OwnerName()
        {
            try
            {
                return CppToCsharpAdapter.OwnerName(my_hash_file_pointer);
                
            }
            catch (SEHException ex)
            {
                return CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
               
            }
            catch
            {
                throw;
            }
        }

        public string CreationDate()
        {
            try
            {
                return CppToCsharpAdapter.CreationDate(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public int FileSize()
        {
            try
            {
                return CppToCsharpAdapter.FileSize(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public int RecordSize()
        {
            try
            {
                return CppToCsharpAdapter.RecordSize(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public int HashFuncID()
        {
            try
            {
                return CppToCsharpAdapter.HashFuncID(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public int NrOfRecsInFile()
        {
            try
            {
                return CppToCsharpAdapter.NrOfRecsInFile(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }

        public int OverflowAreaStart()
        {
            try
            {
                return CppToCsharpAdapter.OverflowAreaStart(my_hash_file_pointer);
            }
            catch (SEHException ex)
            {
                string message = CppToCsharpAdapter.GetLastErrorMessage(this.my_hash_file_pointer);
                throw new Exception(message);
            }
            catch
            {
                throw;
            }
        }
    }
}
