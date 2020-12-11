using System;
using System.Diagnostics;

namespace Task2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "The program is play \'more less\'." +
                "\nCreated by Ivan Zherybor.\n");

            Console.WriteLine("The user guesses the number that the computer guessed in a given range. " +
                              "\nThe user receives hints “more” and “less” if the number was not guessed. " +
                              "\nThe user gets points for the minimum number of used attempts to guess the number.");
            
            Console.WriteLine("Rules: numbers > 0, to exit enter \'-1\'");

            int rangeFrom = 0;
            int rangeTo = 0;

            bool isCorrect = false;
            do 
            {
                try
                {
                    Console.WriteLine("Enter range from:");
                    rangeFrom = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter range to:");
                    rangeTo = Convert.ToInt32(Console.ReadLine());
                    if(rangeFrom < 0 || rangeTo < 0 || rangeFrom > rangeTo || rangeFrom == rangeTo)
                        throw new ArgumentException();
                    
                    isCorrect = true;
                }
                catch
                {
                    isCorrect = false;
                    Console.WriteLine("Invalid input!");
                }
            } while (!isCorrect);

            int selectedValue = new Random().Next(rangeFrom, rangeTo);
            int badTry = 0;
            
            Console.WriteLine("Game started. Good luck!");
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            while (true)
            {
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input == -1)
                    {
                        badTry = -1;
                        break;
                    }
                    
                    if (input < 0)
                        throw new ArgumentException();
                    
                    if(input != selectedValue)
                    {
                        Console.WriteLine(input > selectedValue ? "Less" : "More");
                        badTry++;
                    }

                    if (input == selectedValue)
                    {
                        Console.WriteLine("You guessed!!!");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input!");
                    stopwatch.Start();
                }
            }
            double coef = Math.Log(rangeTo - rangeFrom + 1, 2);
            int n;
            
            if (coef - Math.Floor(coef) > 0.5)
                n = (int)coef + 1;
            else
                n = (int)coef;

            PrintStat(n, badTry, stopwatch.ElapsedMilliseconds);
            
            Console.ReadLine();
        }

        static void PrintStat(double n, double badTry, long milliseconds)
        {
            if (badTry == -1)
                badTry = 0;
            
            Console.WriteLine($"Your score: {CalculateScore(n, badTry)}");
            Console.WriteLine($"Attempts: {badTry}");
            Console.WriteLine($"Game duration: {milliseconds} ms");
        }

        static double CalculateScore(double n, double badTry)
        {
            if (badTry == -1)
                return 0;

            var result = 100 * (n - badTry) * Math.Pow(n, -1);
            if (result < 0)
                return 0;
            
            if (result - Math.Floor(result) > 0)
                result++;

            return result;
        }
    }
}