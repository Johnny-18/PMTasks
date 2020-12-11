using System;
using System.Linq;
using System.Collections.Generic;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "The program is a rock-paper-scissors game." +
                "\nCreated by Ivan Zherybor.");

            Console.WriteLine("Rules:" +
                              "\nYou can enter rock/paper/scissors and the computer generate random value." +
                              "\nValues rules: stone > scissors; scissors > paper; paper > stone." +
                              "\nEnter exit to stop game.");

            string[] values = {"rock", "paper", "scissors"};

            int countGames = 0;
            List<string> results = new List<string>();
            string input;
            
            while(true)
            {
                Console.WriteLine("Enter your variant:");
                input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    int index = 1;
                    foreach (var result in results)
                    {
                        Console.WriteLine($"Game {index}, you {result}.");
                        index++;
                    }

                    Console.WriteLine($"You played {countGames} game(s).");
                    Console.Read();
                    return;
                }
                
                bool isCorrect = false;
                foreach (var value in values)
                {
                    if (input == value)
                    {
                        isCorrect = true;
                        break;
                    }
                }

                if (isCorrect)
                {
                    string computerVar = values[new Random().Next(1, 3)];
                    Console.WriteLine($"You have = {input}, computer have = {computerVar}");
                    countGames++;
                    if (IsWinner(input, computerVar, values) == 1)
                    {
                        results.Add("win");
                        Console.WriteLine("You win)");
                    }
                    else if (IsWinner(input, computerVar, values) == 0)
                    {
                        results.Add("draw");
                        Console.WriteLine("Draw~");
                    }
                    else if(IsWinner(input,  computerVar, values) == -1)
                    {
                        results.Add("lose");
                        Console.WriteLine("You lose(");
                    }
                }
                else
                {
                    Console.WriteLine("You enter incorrect value!" +
                                      "\nYou can enter this value: rock, paper, scissors." +
                                      "\nEnter exit to stop game.");
                }
            }
        }

        static int IsWinner(string player, string computer, string [] values) // 1 - win, 0 - draw, -1 - lose
        {
            if (computer == player)
            {
                return 0;
            }
            
            if ((computer == "rock" && player == "paper") || 
                (computer == "scissors" && player == "rock") ||
                (computer == "paper" && player == "scissors"))
            {
                return 1;
            }
            
            return -1;
        }
    }
}