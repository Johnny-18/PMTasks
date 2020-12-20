using System;
using Library;
using Library.ChatBot;

namespace Task1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            BettingPlatformEmulator menu = new BettingPlatformEmulator();
            menu.Start();
            Console.ReadLine();
        }
    }
}