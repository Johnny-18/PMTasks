using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Library;
using Library.Services;

namespace Task1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pairing parentheses.");
            Console.WriteLine("Program created by Ivan Zherybor.");
            
            Console.WriteLine("Rules:" +
                              "\nYou can enter a string with brackets like [], (), <>, {} " +
                              "\nand if you haven't closed the parenthesis somewhere, the program will tell you.(string limit 100 symbols)");
            
            string input;
            while (true)
            {
                Console.WriteLine("Enter your string:");
                input = Console.ReadLine();
                if (input.Length < 100 && !string.IsNullOrEmpty(input))
                    break;
            
                Console.WriteLine("Invalid string!");
            }

            var checker = new BracketsChecker();
    
            checker.Put(input.ToCharArray());
            
            if(checker.Balanced)
                Console.WriteLine("All brackets have a pair.");
            else
            {
                Console.WriteLine($"Error in position {checker.Index}");
            }
        }
    }
}