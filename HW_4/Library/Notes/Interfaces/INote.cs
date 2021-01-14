using System;

namespace Library.Notes.Interfaces
{
    public interface INote
    {
        int Id { get; }
        string Title { get; }
        string Text { get; }
        DateTime CreatedOn { get; }
    }
}