using System;
using Library.Interfaces;
using Newtonsoft.Json;

namespace Library.Models
{
    public class Note : INote
    {
        [NonSerialized]
        private static int _id;
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        static Note()
        {
            _id = 1;
        }

        public Note(string text)
        {
            Id = _id;
            _id++;
            Text = text;
            CreatedOn = DateTime.UtcNow;

            if (text.Length > 32)
                Title = text.Substring(0, 32);
            else
                Title = text;
        }
    }
}