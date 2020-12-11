using System;

namespace Task1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "The program designed for search prime numbers." +
                "\nThe user enters the range limits to search for prime numbers. " +
                "\nThe program outputs - the found numbers." +
                "\nCreated by Ivan Zherybor.");

            int[] array = new int[10000]; // our array for search, just number 1,2,3,4...
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Console.Write("\nEnter the range limit, from:");
            var rangeFrom = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the range limit, to:");
            var rangeTo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Prime numbers:");
            for (int i = rangeFrom; i < rangeTo; i++)
            {
                if (IsPrime(array[i]))
                {
                    Console.WriteLine($"|{array[i]}|");
                }
            }
            
            Console.ReadLine();
        }

        static bool IsPrime(int value)
        {
            for (int i = 2; i < Math.Sqrt(value) + 1; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}