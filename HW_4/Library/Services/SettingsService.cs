using System.IO;
using System.Text.Json;
using Library.Models;

namespace Library.Services
{
    public class SettingsService
    {
        private readonly string _path = "settings.json";

        public Settings GetSettings()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<Settings>(json);
        }
    }
}