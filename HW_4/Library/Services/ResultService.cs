using System.IO;
using System.Text.Json;
using Library.Models;

namespace Library.Services
{
    public class ResultService
    {
        private readonly string _path = "result.json";

        public void AddToFile(Result result)
        {
            var json = JsonSerializer.Serialize(result);
            File.WriteAllText(_path, json);
        }
    }
}