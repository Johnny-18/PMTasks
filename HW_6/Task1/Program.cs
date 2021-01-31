using System;
using System.Diagnostics;
using System.Linq;
using HW_6_Library.Services;

namespace Task1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Searching primary numbers by LINQ and PLINQ.");
            Console.WriteLine("Program created by Ivan Zherybor.");

            var service = new PrimaryNumberService();

            int from = 0;
            int to = 1;

            while(true)
            {
                from = InteractionWithUser.GetIntFromUser("Enter range from:");
                to = InteractionWithUser.GetIntFromUser("Enter range to:");
                
                if (from <= to)
                    break;

                Console.WriteLine("Enter correct range! \'From\' must be smaller then \'to\'.");
            }

            int numbers;
            var sw = new Stopwatch();
            while (true)
            {
                Console.WriteLine("Searching method:");
                Console.WriteLine("1. LINQ");
                Console.WriteLine("2. PLINQ");
                
                var input = Console.ReadLine();
                if (input == "1")
                {
                    sw.Start();
                    Console.WriteLine("LINQ");
                    numbers = service.GetLinq(from, to);
                    break;
                }
                
                if (input == "2")
                {
                    sw.Start();
                    Console.WriteLine("PLINQ");
                    numbers = service.GetPlinq(from, to);
                    break;
                }
                
                Console.WriteLine("Enter correct action!");
            }
            
            Console.WriteLine($"Was found {numbers} primary numbers, work time: {sw.Elapsed}.");
        }
    }
}