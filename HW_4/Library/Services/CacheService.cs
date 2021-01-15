using System.Collections.Generic;
using System.IO;
using Library.Models;
using Newtonsoft.Json;

namespace Library.Services
{
    public class CacheService
    {
        private List<Cache> _caches;

        private readonly RequestService _requestService;

        private readonly string _path;

        public CacheService(string path)
        {
            _requestService = new RequestService();
            _path = path;
        }

        public List<Cache> GetCaches()
        {
            if (_caches == null)
            {
                var json = File.ReadAllText(_path);
                _caches = JsonConvert.DeserializeObject<List<Cache>>(json);
            }
            
            return _caches;
        }

        public void SetCaches(string request)
        {
            var json = _requestService.Request(request).Result;
            using (var file = new FileStream(_path, FileMode.Create, FileAccess.Write))
            {
                var writer = new StreamWriter(file);
                writer.Write(json);
                
                writer.Flush();
            }
        }
    }
}