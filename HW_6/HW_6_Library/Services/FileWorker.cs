using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

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
    }
}