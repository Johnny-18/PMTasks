using System;
using System.Collections.Generic;
using Library.Interfaces;
using Library.Model;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary with key.");
            Console.WriteLine("Program created by Ivan Zherybor.");
            Console.WriteLine("Rules:" +
                              "\nYou can enter length of dictionary , but length must be less then 50." +
                              "\nThere should be no repetitions when filling out the dictionary." +
                              "\nWrite exit to stop program.");

            int length;
            while (true)
            {
                Console.WriteLine("Enter count of dictionary length:");
                var input = Console.ReadLine();

                if (int.TryParse(input, out length) && length < 50)
                    break;

                Console.WriteLine("Invalid value! Dictionary length must be number and less then 50");
            }
            
            Console.Clear();
            var dictionary = new Dictionary<IRegion, IRegionSettings>();
            for (int i = 0; i < length;)
            {
                Console.WriteLine("Enter element of dictionary in format: brand, country, website");
                var input = Console.ReadLine();
                if (input == "exit")
                    return;

                var splitted = input.Split(',');
                if (splitted.Length == 3)
                {
                    var region = new Region(splitted[0].Trim(), splitted[1].Trim());
                    if (!dictionary.ContainsKey(region))
                    {
                        dictionary.Add(region, new RegionSettings(splitted[2].Trim()));
                        i++;
                        continue;
                    }

                    Console.WriteLine("This is duplicate! Enter another brand and country!\n");
                    continue;
                }

                Console.WriteLine("Invalid string!\n");
            }

            Console.Clear();
            Console.WriteLine("\nDictionary:");
            foreach (var element in dictionary)
            {
                Console.WriteLine(element.Key + " " + element.Value);
            }
        }
    }
}