using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.Notes.Services
{
    public class FileWorker
    {
        private string _path = "notes.json";

        public async void Serialize<T>(List<T> notes) where T : class
        {
            var json = JsonConvert.SerializeObject(notes);
            using (var file = new FileStream(_path, FileMode.Append, FileAccess.Write))
            {
                var writer = new StreamWriter(file);
                await writer.WriteAsync(json);
                
                await writer.FlushAsync();
            }
        }

        public async Task<List<T>> Deserialize<T>() where T : class
        {
            List<T> desObjects;
            using (var file = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                var reader = new StreamReader(file);
                var jsonFromFile = await reader.ReadToEndAsync();

                desObjects = JsonConvert.DeserializeObject<List<T>>(jsonFromFile);
            }

            return desObjects;
        }
    }
}