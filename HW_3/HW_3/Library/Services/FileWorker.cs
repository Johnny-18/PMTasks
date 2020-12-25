using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Library.Services
{
    public class FileWorker
    {
        private FileStream _file;

        public bool Serialize(string fileName, object obj)
        {
            _file = new FileStream($"{Directory.GetCurrentDirectory()}\\{fileName}",FileMode.Append);
            
            using (var writer = new StreamWriter(_file))
            {
                writer.WriteLine(obj.ToString());
                writer.Flush();
                return true;
            }
        }

        public List<string> Deserialize(string fileName)
        {
            _file = new FileStream($"{Directory.GetCurrentDirectory()}\\{fileName}", FileMode.Open);
            
            List<string> fromFile = new List<string>();
            using (var reader = new StreamReader(_file))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    fromFile.Add(str);
                }
            }
        
            return fromFile;
        }
    }
}