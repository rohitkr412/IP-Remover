using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace IPRemover
{
    public class LogFileClass
    {
        private string RegEx_IP = "\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}";
        private string ReplaceString = "x.x.x.x";
        private string Path { get; set; }

        public LogFileClass(string path)
        {
            Path = path;
        }

        public string ReadContent()
        {
            StreamReader reader = new StreamReader(Path);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        public void WriteContent(string content)
        {
            StreamWriter writer = new StreamWriter(Path);
            writer.Write(content);
            writer.Close();
        }

        public String Mask(string content)
        {
            return Regex.Replace(content,RegEx_IP, ReplaceString);
        }
    }
}
