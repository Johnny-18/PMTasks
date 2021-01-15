using System;
using Library.Interfaces;
using Newtonsoft.Json;

namespace Library.Models
{
    public class Note : INote
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        public Note(int id, string text)
        {
            Id = id;
            Text = text;
            CreatedOn = DateTime.UtcNow;

            if (text.Length > 32)
                Title = text.Substring(0, 32);
            else
                Title = text;
        }
    }
}