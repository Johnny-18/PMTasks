using System;
using Library.Notes.Interfaces;

namespace Library.Notes.Models
{
    public class Note : INote
    {
        private static int _id;
        public int Id { get; }
        public string Title { get; }
        public string Text { get; }
        public DateTime CreatedOn { get; }

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