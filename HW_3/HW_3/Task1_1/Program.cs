using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using Library;
using Library.Services;

namespace Task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program created by Ivan Zherybor.");
            Console.WriteLine("Rules:" +
                            "\nYou must enter a string with set of number separated commas, like 1, 2, 3.");

            ServiceForArray service = new ServiceForArray();

            int[] arr;
            while (true)
            {
                Console.WriteLine("Enter your string:");
                var input = Console.ReadLine();

                try
                {
                    if (string.IsNullOrEmpty(input))
                        throw new ArgumentNullException();

                    arr = input.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid string!");
                }
            }

            Console.WriteLine($"Min element: {service.MinElement(arr)}");
            Console.WriteLine($"Max element: {service.MaxElement(arr)}");
            Console.WriteLine($"Sum elements: {service.SumElements(arr)}");
            Console.WriteLine($"Average element: {service.AvgElement(arr)}");
            Console.WriteLine($"Standard deviation: {service.StandardDeviation(arr)}");
            Console.WriteLine($"Sorted array:");
            service.SortElements(ref arr);
            foreach (var element in arr)
            {
                Console.Write($"{element} ");
            }

        }
    }
}