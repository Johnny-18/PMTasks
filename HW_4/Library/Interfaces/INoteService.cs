using System.Collections.Generic;
using Library.Models;

namespace Library.Interfaces
{
    public interface INoteService
    {
        void CreateNote(string text);
        void DeleteNote(int id);
        List<Note> GetNotes(string strSearch = "");
        Note GetNote(int id);
    }
}