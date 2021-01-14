using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.Services
{
    /// <summary>
    /// Class can work with file, can writing to file objects and get data from files
    /// </summary>
    public class FileWorker
    {
        private string _path;

        public FileWorker(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Serialize data to file.
        /// </summary>
        /// <param name="objects">Objects to serialize</param>
        /// <typeparam name="T">Type of serialized value</typeparam>
        public void Serialize<T>(T objects) where T : class
        {
            var json = JsonConvert.SerializeObject(objects);
            File.WriteAllText(_path,json);
        }

        /// <summary>
        /// Deserialize data from file.
        /// </summary>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <returns>Data from file in T type</returns>
        public async Task<T> Deserialize<T>() where T : class
        {
            T desObjects ;
            using (var file = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                var reader = new StreamReader(file);
                var jsonFromFile = await reader.ReadToEndAsync();

                desObjects = JsonConvert.DeserializeObject<T>(jsonFromFile);
            }

            return desObjects;
        }
    }
}