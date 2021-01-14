using System.Collections.Generic;

namespace Library.Notes.Interfaces
{
    public interface INoteService
    {
        void CreateNote(string text);
        void DeleteNote(int id);
        List<INote> GetNotes(string strSearch = "");
        INote GetNote(int id);
    }
}