using System.Collections.Concurrent;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using HW_6_Library.Models.LoginTask;
using Microsoft.VisualBasic.FileIO;

namespace HW_6_Library.Services
{
    public class FileWorker
    {
        public void Serialize<T>(string path, T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
        }

        public async Task<T> Deserialize<T>(string path)
        {
            var json = await File.ReadAllTextAsync(path);
            
            if (string.IsNullOrEmpty(json))
                return default;
            
            return JsonSerializer.Deserialize<T>(json);
        }

        public ConcurrentQueue<Login> CsvParser(string path)
        {
            var storage = new ConcurrentQueue<Login>();

            using var parser = new TextFieldParser(@path) {TextFieldType = FieldType.Delimited};
            parser.SetDelimiters(",");
            
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if(fields == null || fields.Rank != 1)
                    continue;
                    
                var login = new Login
                {
                    LoginValue = fields[0],
                    Password = fields[1]
                };

                storage.Enqueue(login);
            }

            return storage;
        }
    }
}