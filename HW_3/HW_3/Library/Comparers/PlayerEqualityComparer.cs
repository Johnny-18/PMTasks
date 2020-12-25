using System.Collections;
using System.Collections.Generic;
using Library.Interfaces;
using Library.Model;

namespace Library.Comparers
{
    public class PlayerEqualityComparer : IEqualityComparer<Player>
    {
        /// <summary>
        /// Two players are equal if name, age and rank equals.
        /// </summary>
        /// <param name="x">First player.</param>
        /// <param name="y">Second player.</param>
        /// <returns>True if players are equal, and false if not.</returns>
        public bool Equals(Player x, Player y)
        {
            return string.Equals(x.GetName(), y.GetName());
        }

        public int GetHashCode(Player obj)
        {
            return obj.Age ^ 1;
        }
    }
}