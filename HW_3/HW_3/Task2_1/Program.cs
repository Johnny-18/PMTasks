using System;
using System.IO;
using Library.Menu;

namespace Task2_1
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("ERP Reports Bot");
            Console.WriteLine("Program created by Ivan Zherybor.");
            Console.WriteLine("Rules:" +
                              "\nThis is bot-menu for requests various reports on warehouse balances." +
                              "\n");
            ChatBot chatBot = new ChatBot();
            try
            {
                chatBot.Start();
            }
            catch
            {
                Console.WriteLine("Something wrong with file reading!");
                return -1;
            }

            return 0;
        }
    }
}