using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace IPRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            string DirectoryPath = GetDirectoryPath();          //go to specified directory
            FileInfo[] FileList = GetAllFiles(DirectoryPath);   //get list of all files in directory
            OperateEachFile(FileList);                          //Iterate through each file
            Console.Write("\nDone");
            Console.ReadKey();
        }         
      
        public static string GetDirectoryPath()
        {
            return "C:/Users/Rohit/Documents/GitHub/IPRemover/IPRemover/LogFiles";      //Put your Directory Path here instead of String.Empty
        }


        public static FileInfo[] GetAllFiles(string DirectoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(DirectoryPath);
            return directory.GetFiles();
        }

        public static void OperateEachFile(FileInfo[] FileList)
        {
            foreach(FileInfo f in FileList)
            {
                string filepath =  GetDirectoryPath() +"/" + f.Name;
                LogFileClass file = new LogFileClass(filepath);
                string content = file.ReadContent();
                content = file.Mask(content);
                file.WriteContent(content);
                PrintSuccess(f.Name);
            }
        }

        public static void PrintSuccess(string filename)
        {
            Console.Write("\nSuccess - "+filename);
        }
    }
}


