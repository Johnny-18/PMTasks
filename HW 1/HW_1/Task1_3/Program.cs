using System;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon = Math.Pow(2001, -1);
            
            Console.WriteLine(
                "The program designed for calculates sum of mathematical series. " +
                "\nEnd count on element less than epsilon, where epsilon = 1/year of birth programmer." +
                "\nThis mathematical series will be calculate = (1/i*(i+1), i from 1 to infinity." +
                $"\nEpsilon = {epsilon}" +
                "\nCreated by Ivan Zherybor.");

            Console.WriteLine($"Result: {CalculateSeries(epsilon)}");
            
            Console.ReadLine();
        }

        static double CalculateSeries(double epsilon)
        {
            double result = 0;
            double element = 1;
            var i = 1;
            
            while (element > epsilon)
            {
                element = Math.Pow(i * (i + 1), -1);
                result += element;
                i++;
            }

            return result;
        }
    }
}