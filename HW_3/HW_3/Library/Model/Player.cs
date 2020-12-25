using System.Collections.Generic;
using Library.Comparers;
using Library.Enum;
using Library.Interfaces;

namespace Library.Model
{
    public class Player : IPlayer
    {
        public int Age { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PlayerRank Rank { get; }

        public static IEqualityComparer<Player> EqualityComparer { get; } = new PlayerEqualityComparer();

        public Player(string firstName, string lastName, int age, PlayerRank rank)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Rank = rank;
        }

        public string GetName()
        {
            return FirstName + " " + LastName;
        }

        public override string ToString()
        {
            return $"{GetName()} age: {Age}, rank: {Rank}";
        }
    }
}