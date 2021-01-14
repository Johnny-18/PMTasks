using System;
using System.Collections.Generic;
using System.IO;
using Library.Menu;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            NotesMenu menu = new NotesMenu("notes.json");
            menu.PrintAboutCreatorAndProgram();
            menu.Start();
            //todo index from file to not changed
        }
    }
}