using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Library;
using Library.Comparers;
using Library.Enum;
using Library.Model;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CS championship!!!");
            Console.WriteLine("Program created by Ivan Zherybor.");

            List<Player> players = new List<Player>();
            players.Add(new Player("Ivan", "Ivanenko", 29, PlayerRank.Captain));
            players.Add(new Player("Peter", "Petrenko", 19, PlayerRank.Private));
            players.Add(new Player("Ivan", "Ivanov", 59, PlayerRank.General));
            players.Add(new Player("Ivan", "Snezko", 52, PlayerRank.Lieutenant));
            players.Add(new Player("Alex", "Zeshko", 34, PlayerRank.Colonel));
            players.Add(new Player("Ivan", "Ivanenko", 29, PlayerRank.Captain));
            players.Add(new Player("Peter", "Petrenko", 19, PlayerRank.Private));
            players.Add(new Player("Vasiliy", "Sokol", 34, PlayerRank.Major));
            players.Add(new Player("Alex", "Alexeenko", 31, PlayerRank.Major));

            players = players.Distinct(new PlayerEqualityComparer()).ToList();

            Console.WriteLine("Sorted by name:");
            players.Sort(new PlayerComparerOnName());
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine("\nSorted by age:");
            players.Sort(new PlayerComparerOnAge());
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine("\nSorted by rank:");
            players.Sort(new PlayerComparerOnRank());
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}