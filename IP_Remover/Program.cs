using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_Remover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string RootPath = GetDirectoryPath(); //Go to specified directory

                List<string> AllLogFiles = GetAllLogFiles(RootPath);

                OperateEachFile(AllLogFiles);

                Console.ReadKey();
            }

            catch(Exception)
            {
                Console.Write("\nException in Main");
            }
        }

        public static string GetDirectoryPath()
        {
            try
            {
                string LocationOfEXE = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string DirectoryOfEXE = System.IO.Path.GetDirectoryName(LocationOfEXE).ToString();
                return DirectoryOfEXE;
            }

            catch(Exception)
            {
                Console.Write("\nException in GetDirectoryPath");
                throw;
            }
        }

        public static List<string> GetAllLogFiles(string RootPath)
        {
            try
            {
                string[] AllFilesAndFolders = System.IO.Directory.GetFileSystemEntries(RootPath);
                List<string> AllLogFiles = new List<string>();
                foreach( string s in AllFilesAndFolders)
                {
                    if (IsALogFile(s))
                        AllLogFiles.Add(s);
                }

                return AllLogFiles;
            }
            catch(Exception)
            {
                Console.Write("\nExceptin in GetAllLogFiles()");
                throw;
            }
        }

        public static bool IsALogFile(string file)
        { 
            try
            {
                file = file.ToLower();
                if (file.EndsWith(".txt") || file.EndsWith(".log"))
                    return true;

                else
                    return false;
            }
            catch(Exception)
            {
                Console.Write("\nException in IsALogFile()");
                throw;
            }
        }


        public static void OperateEachFile(List<string> AllLogFiles)
        {
            try
            {
                foreach( string filepath in AllLogFiles)
                {
                    LogFile file = new LogFile(filepath); //initialize the file

                    string content = file.ReadContent(); //get contents of the file

                    content = file.Mask(content);  // mask the IPs

                    file.WriteContent(content);     //write content after all masking

                    PrintSuccess(filepath);
                }
            }
            catch(Exception)
            {
                Console.Write("\nException in OperateEachFile()");
                throw;
            }
        }

        public static void PrintSuccess(string filename)
        {
            Console.Write("\nSuccess - "+filename);
        }
    }
}
