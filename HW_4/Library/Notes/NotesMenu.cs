using System;
using Library.Notes.Services;

namespace Library.Notes
{
    public class NotesMenu
    {
        private NoteService _service = new NoteService();

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
                string input = Console.ReadLine();
                
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
                        Console.WriteLine("Enter correct number, from 1 to 5.");
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
            
            Console.WriteLine("Enter string for search:");
            var input = Console.ReadLine();
            _service.GetNotes(input);
        }

        private void ReviewNote()
        {
            Console.Clear();
            Console.WriteLine("Review notes");
            for (;;)
            {
                Console.WriteLine("Enter id of note:");
                var input = Console.ReadLine();
                int id;
                if (int.TryParse(input, out id))
                {
                    var note = _service.GetNote(id);
                    Console.WriteLine($"Id: {note.Id}, title: {note.Title}, text: {note.Text}, date on created: {note.CreatedOn}.");
                    return;
                }
                
                Console.WriteLine("Enter correct number!");
            }
        }

        private void CreateNote()
        {
            Console.Clear();
            Console.WriteLine("Create note");

            for (;;)
            {
                Console.WriteLine("Enter your note:");
                var input = Console.ReadLine();

                input = input?.TrimEnd().TrimStart();
                if (!string.IsNullOrEmpty(input))
                {
                    _service.CreateNote(input);
                    return;
                }
                
                Console.WriteLine("String should be not empty!");
            }
        }

        private void DeleteNote()
        {
            
        }
    }
}