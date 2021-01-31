using System;

namespace HW_6_Library.Services
{
    public static class InteractionWithUser
    {
        public static int GetIntFromUser(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();

                if (int.TryParse(input, out var from))
                    return from;

                Console.WriteLine("Enter correct value!");
            }
        }
    }
}