using System;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "The program designed for calculates margin and probability of event outcomes." +
                "\nUser enter from console names of player and coef, W1, Х and W2." +
                "\nCreated by Ivan Zherybor.");

            Console.Write("Enter name of first player:");
            var player1 = Console.ReadLine();

            Console.Write("\nEnter name of second player:");
            var player2 = Console.ReadLine();

            Console.Write("\nEnter coefficient W1:");
            var w1Coef = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter coefficient X:");
            var xCoef = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nEnter coefficient W2:");
            var w2Coef = Convert.ToDouble(Console.ReadLine());

            var percentW1 = CalculatePercent(w1Coef);
            var percentW2 = CalculatePercent(w2Coef);
            var percentX = CalculatePercent(xCoef);
            var margin = CalculateMargin(percentW1, percentX, percentW2);
            
            Console.WriteLine($"Win {player1}: {percentW1}%" +
                              $"\nWin {player2}: {percentW2}%" +
                              $"\nDraw: {percentX}%" +
                              $"\nMargin: {margin}%");
            
            Console.ReadLine();
        }

        static double CalculatePercent(double coef)
        {
            return Math.Round(100 / coef, 2);
        }

        static double CalculateMargin(double percentW1, double percentX, double percentW2)
        {
            return Math.Round(percentW1 + percentW2 + percentX - 100, 2);
        }
    }
}