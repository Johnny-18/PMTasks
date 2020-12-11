using System;
using System.Runtime.InteropServices;

namespace Task2_2
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(
                    "The program is area calculator for standard shapes: circle, square, rectangle, triangle." +
                    "\nCreated by Ivan Zherybor.");

                Console.WriteLine("Rules:" +
                                  "\nIf you write rect, you must give value of 2 sides, example: rect 1 2" +
                                  "\nif you write square, you must give value of side, example: square 1" +
                                  "\nif you write circle, you must give value of radius, example: circle 1" +
                                  "\nif you write triangle, you must give value of side and heigth to this side, example: triangle 1 2");
                
                Console.WriteLine("Commands:" +
                                  "\nrect side1 side2," +
                                  "\nsquare side," +
                                  "\ncircle radius," +
                                  "\ntriangle side heigh," +
                                  "\nexit to stop program.");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter your shape and values:");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "exit")
                        {
                            return 0;
                        }

                        Console.Write("\nResult:");
                        Console.Write($"{CalculateSquare(input.Split(' '))}");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("Rules:" +
                                          "\nIf you write rect, you must give value of 2 sides," +
                                          "\nif you write square, you must give value of side," +
                                          "\nif you write circle, you must give value of radius," +
                                          "\nif you write triangle, you must give value of side and heigth to this side.");
                    }
                }
            }
            else
            {
                try
                {
                    Console.WriteLine(CalculateSquare(args));
                }
                catch
                {
                    return -1;
                }
            }

            return 0;
        }

        static double CalculateSquare(string[] inputArr)
        {
            double squareShape = 0;
            if (inputArr[0].ToLower() == "triangle")
            {
                squareShape = TriangleSquare(Convert.ToDouble(inputArr[1]), Convert.ToDouble(inputArr[2]));
            }
            else if (inputArr[0].ToLower() == "circle")
            {
                squareShape = CircleSquare(Convert.ToDouble(inputArr[1]));
            }
            else if (inputArr[0].ToLower() == "square")
            {
                squareShape = SquareArea(Convert.ToDouble(inputArr[1]));
            }
            else if (inputArr[0].ToLower() == "rect")
            {
                squareShape = RectSquare(Convert.ToDouble(inputArr[1]), Convert.ToDouble(inputArr[2]));
            }

            return squareShape;
        }

        static double RectSquare(double side1, double side2)  // Square = a*b
        {
            return side1 * side2;
        }

        static double CircleSquare(double radius) // Square = Pi*R*R
        {
            return Math.PI*radius*radius;
        }

        static double TriangleSquare(double side, double height) // Square = (h*a)/2
        {
            return 0.5 * side * height;
        }

        static double SquareArea(double side) // Square = a*a
        {
            return side * side;
        }
    }
}