using System.Collections.Generic;
using Library.Notes.Interfaces;

namespace Library.Notes.Services
{
    public class NoteService : INoteService
    {
        private FileWorker _fw;

        public NoteService()
        {
            _fw = new FileWorker();
        }
        
        public void CreateNote(string text)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<INote> GetNotes(string strSearch = "")
        {
            throw new System.NotImplementedException();
        }

        public INote GetNote(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}