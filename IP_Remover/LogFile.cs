using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IP_Remover
{
    public class LogFile
    {
        private string RegEx_IP = "\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}";

        private string ReplaceString = "x.x.x.x";

        private string Path { get; set; }

        public LogFile(string path)
        {
            Path = path;
        }

        public string ReadContent()
        {
            try
            {
                StreamReader reader = new StreamReader(Path);
                string content = reader.ReadToEnd();
                reader.Close();
                return content;
            }
            catch(Exception)
            {
                Console.Write("\nException in ReadContent()");
                throw;
            }
        }

        public void WriteContent(string content)
        {
            try
            {
                StreamWriter writer = new StreamWriter(Path);
                writer.Write(content);
                writer.Close();
            }
            catch(Exception)
            {
                Console.Write("\nException in WriteContent()");
                throw;
            }
        }

        public string Mask(string content)
        {
            return Regex.Replace(content,RegEx_IP,ReplaceString);
        }
    }
}
