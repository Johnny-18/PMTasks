using System;
using System.Linq;
using Library.Models;
using Library.Services;

namespace Library.Menu
{
    public class NotesMenu
    {
        private readonly NoteService _service;

        public NotesMenu(string path)
        {
            _service = new NoteService(path);
        }

        public void Start()
        {
            Console.WriteLine("Menu:");

            for (;;)
            {
                Console.WriteLine("1.Find notes." +
                                  "\n2.Review notes" +
                                  "\n3.Create note" +
                                  "\n4.Delete note" +
                                  "\n5.Exit");
                
                Console.WriteLine("Choose your action:");
                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        FindNotes();
                        break;
                    case "2":
                        ReviewNote();
                        break;
                    case "3":
                        CreateNote();
                        break;
                    case "4":
                        DeleteNote();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Enter correct number, from 1 to 5!");
                        break;
                }
            }
        }

        public void PrintAboutCreatorAndProgram()
        {
            Console.WriteLine("Program for user notes.");
            Console.WriteLine("Program was created by Ivan Zherybor.");
        }

        private void FindNotes()
        {
            Console.Clear();
            Console.WriteLine("Find notes");
            
            Console.Write("Enter string for search:");
            var input = Console.ReadLine();

            var notes = _service.GetNotes(input?.TrimStart().TrimEnd());
            if (notes?.Count == 0 || notes == null)
            {
                Console.WriteLine("Notes not found!");
                return;
            }

            foreach (var note in notes)
            {
                Console.WriteLine($"Id: {note.Id}, title: {note.Title}, date on created: {note.CreatedOn}.");
            }

            Console.WriteLine();
        }

        private void ReviewNote()
        {
            Console.Clear();
            Console.WriteLine("Review notes");
            Console.WriteLine("Write command \"back\" to stop reviewing.");

            for (;;)
            {
                Console.WriteLine("Enter id of note:");
                var input = Console.ReadLine(); // expected id of note
                if (input == "back")
                    return;
                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Enter correct id!");
                    continue;
                }

                if (int.TryParse(input, out var id))
                {
                    var note = _service.GetNote(id);
                    Console.WriteLine(note == null
                        ? "Note not found!"
                        : $"Id: {note.Id}, title: {note.Title}, date on created: {note.CreatedOn}, text: {note.Text}.");
                    return;
                }

                Console.WriteLine("Note not found!");
            }
        }

        private void CreateNote()
        {
            Console.Clear();
            Console.WriteLine("Create note");

            for (;;)
            {
                Console.WriteLine("Enter text of your note:");
                var input = Console.ReadLine(); // expected text of note
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Text should be not empty!");
                    continue;
                }
                
                if (input.ToLower() == "back")
                    return;
                
                input = input.TrimEnd().TrimStart();
                _service.CreateNote(input);
                Console.WriteLine("Note was created!");
                return;
            }
        }

        private void DeleteNote()
        {
            Console.Clear();
            Console.WriteLine("Delete note");

            Console.WriteLine("Enter id of note:");
            var input = Console.ReadLine(); // expected id of note
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Enter correct id!");
            }
            if(input?.ToLower() == "back")
                return;

            Note note;
            if(int.TryParse(input, out int id))
                note = _service.GetNote(id);
            else
            {
                Console.WriteLine("Note not found");
                return;
            }

            for (;;)
            {
                Console.WriteLine($"You want to delete note with title{note.Title}?");
                Console.WriteLine("Choose your action:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                input = Console.ReadLine(); // expected number of action

                switch (input?.ToLower())
                {
                    case "1":
                        _service.DeleteNote(note.Id);
                        Console.WriteLine("Deleted!");
                        return;
                    case "2":
                        return;
                    case "back":
                        return;
                    default:
                        Console.WriteLine("Enter correct action!");
                        break;
                }
            }
        }
    }
}