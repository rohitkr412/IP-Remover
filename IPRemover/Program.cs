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
            Console.WriteLine("Beginning");
            ReplaceInFile("C:/Users/Rohit/Documents/logs.log", "24.236.252.67", "x.x.x.x");
            Console.WriteLine("Ending");
            Console.ReadKey();
        }   

        
        public static void ReplaceInFile(string FilePath, string SearchText, string ReplaceText)
        {
            try
            {
                StreamReader reader = new StreamReader(FilePath);
                string content = reader.ReadToEnd();
                reader.Close();

                content = Regex.Replace(content, SearchText, ReplaceText);

                StreamWriter writer = new StreamWriter(FilePath);
                writer.Write(content);
                writer.Close();
            }

            catch(Exception e)
            {
                Console.Write("\n"+e.Message);
            }
            
        }
    }
}


