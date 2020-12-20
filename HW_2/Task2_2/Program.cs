using System;
using Library;
using Library.ChatBot;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BettingPlatformEmulator menu = new BettingPlatformEmulator();
            menu.Start();
        }
    }
}