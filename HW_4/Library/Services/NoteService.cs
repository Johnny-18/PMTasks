using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Library.Interfaces;
using Library.Models;

namespace Library.Services
{
    public class NoteService : INoteService, ISaveWork
    {
        private readonly FileWorker _fw;

        private readonly List<Note> _notes;

        public NoteService(string path)
        {
            _fw = new FileWorker(path);
            _notes = _fw.Deserialize<List<Note>>().Result;
            
            if(_notes == null)
                _notes = new List<Note>();
        }
        
        public void CreateNote(string text)
        {
            _notes.Add(new Note(text));
            SaveWork();
        }

        public void DeleteNote(int id)
        {
            _notes.Remove(_notes.FirstOrDefault(x => x.Id == id));
            SaveWork();
        }

        public List<Note> GetNotes(string strSearch = "")
        {
            if(strSearch == "")
                return _notes;

            var notes = _notes.Where(x =>
                x.Id.ToString().Contains(strSearch) || x.Text.Contains(strSearch) || x.Title.Contains(strSearch) ||
                x.CreatedOn.ToString(CultureInfo.InvariantCulture).Contains(strSearch)).ToList();
            
            return notes;
        }

        public Note GetNote(int id)
        {
            return _notes.FirstOrDefault(x => x.Id == id);
        }

        public void SaveWork()
        {
            _fw.Serialize(_notes);
        }
    }
}