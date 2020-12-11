using System;

namespace Task2_3
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(
                    "The program is utility for quick statistics on an array of numbers." +
                    "\nYou can see statistics on an array of integers: minimum element, maximum element," +
                    "\nsum of elements, arithmetic mean, standard deviation." +
                    "\nCreated by Ivan Zherybor.\n");

                Console.Write("Enter array length:");
                int length = Convert.ToInt32(Console.ReadLine());
                int[] inputArray = new int[length];
                int i = 0;

                Console.WriteLine("Enter numbers:");
                while (i < length)
                {
                    try
                    {
                        var element = Convert.ToInt32(Console.ReadLine());
                        if (element < 0)
                            throw new ArgumentException();

                        inputArray[i] = element;
                        i++;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid value, enter again!");
                    }
                }

                SortArray(ref inputArray);
                var result = GetAnswer(inputArray);
                
                Console.WriteLine(
                    $"Min: {result[0]}, max: {result[1]}, sum: {result[2]}, average value: {result[3]}, standard deviation: {result[4]}");

                Console.WriteLine("Sorted array:");
                PrintArray(inputArray);

                Console.ReadLine();
            }
            else
            {
                try
                {
                    int[] arrayInput = new int[args.Length];
                    for (int i = 0; i < arrayInput.Length; i++)
                    {
                        arrayInput[i] = Convert.ToInt32(args[i]);
                    }
                    
                    SortArray(ref arrayInput);
                    var result = GetAnswer(arrayInput);

                    Console.WriteLine(result[0] + " " + result[1] + " " + result[2] + " " + result[3] + " " + result[4]);
                    PrintArray(arrayInput);
                }
                catch
                {
                    return -1;
                }
            }

            return 0;
        }

        static void PrintArray(int[] array)
        {
            foreach (var number in array)
            {
                Console.WriteLine(number);
            }
        }

        static void SortArray(ref int[] array)
        {
            for (int i = 1; i < array.Length; ++i) { 
                int key = array[i]; 
                int j = i - 1; 
                
                while (j >= 0 && array[j] > key) { 
                    array[j + 1] = array[j]; 
                    j = j - 1; 
                } 
                array[j + 1] = key; 
            } 
        }

        static double[] GetAnswer(int [] inputArray)
        {
            double[] answers = new double[5];
            answers[0] = inputArray[0];
            answers[1] = inputArray[inputArray.Length - 1];
            answers[2] = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                answers[2] += inputArray[i];
            }

            answers[3] = answers[2] * Math.Pow(inputArray.Length, -1);

            double sqSum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                sqSum += Math.Pow(inputArray[i] - answers[3], 2);
            }

            answers[4] = sqSum * Math.Pow(inputArray.Length, -1);

            return answers;
        }
    }
}