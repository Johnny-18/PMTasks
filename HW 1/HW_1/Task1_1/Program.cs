using System;

namespace Task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "The program is designed to calculate a mathematical function and work the user with the console." +
                "\nCreated by Ivan Zherybor." +
                "\nSuch a function will be calculated y=((e^a+4*lg(c))/sqrt(b))*|arctg(d)|+5/sin(a)" +
                "\nWhere b = year of birth of the programmer (2001), с = month of birth of the programmer(8), d = day of birth of the programmer(18).");

            Console.Write("\nEnter your parameter а:");
            var aReadValue = Console.Read(); // user parameter for function
            
            int b = 2001; // year of birth
            int c = 8; // month of birth
            int d = 18; // day of birth

            Console.WriteLine($"Result = {MathFunction(aReadValue, b, c, d)}");
            Console.Read();
        }

        public static double MathFunction(int a, int b, int c, int d) // this function will be calculated our math formula 
        {
            return ((Math.Pow(Math.E, a) + 4 * Math.Log(c)) / Math.Sqrt(b)) * Math.Pow(Math.Tan(d), -1) + 5 / Math.Sin(a);
        }
    }
}