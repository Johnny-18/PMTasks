using System.Collections.Generic;
using System.IO;
using Library.Model;

namespace Library.Services
{
    public class TagService
    {
        private readonly FileWorker _fileWorker;
        private readonly string _fileName;

        public TagService(string fileNameTag = "")
        {
            _fileWorker = new FileWorker();
            
            if (string.IsNullOrEmpty(fileNameTag))
                _fileName = "tag.csv";
            else
                _fileName = fileNameTag;
        }

        public List<Tag> GetAllTagsFromFile()
        {
            var tags = new List<Tag>();
            
            var fromFile = _fileWorker.Deserialize(_fileName);
            foreach (var str in fromFile)
            {
                var splitted = str.Split(';');
                var product = new Tag(splitted[0],splitted[1]);
                tags.Add(product);
            }

            return tags;
        }
    }
}