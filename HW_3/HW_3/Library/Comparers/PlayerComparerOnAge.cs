using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Comparers
{
    public class PlayerComparerOnAge : IComparer<Player>
    {
        /// <summary>
        /// Comparer on players ages.
        /// </summary>
        /// <param name="x">First player.</param>
        /// <param name="y">Second player.</param>
        /// <returns>Return 1 if first > second,
        ///                 -1 if second > first,
        ///                 0 if first == second.</returns>
        /// <exception cref="ArgumentNullException">If arguments are null.</exception>
        public int Compare(Player x, Player y)
        {
            if(x == null || y == null)
                throw new ArgumentNullException();

            if (x.Age > y.Age)
                return 1;

            if (y.Age > x.Age)
                return -1;

            return 0;
        }
    }
}