using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HW_6_Library.Services
{
    public class PrimaryNumberService
    {
        public int GetLinq(int @from, int to)
        {
            Stopwatch sw = new Stopwatch();
                
            sw.Start();

            var numbers = Enumerable.Range(@from, to - @from).Count(n =>
                n >= 2 && Enumerable.Range(2, (int) (Math.Sqrt(n) + 1) - 2).All(x => n > x && n % x != 0));

            sw.Stop();

            return numbers;
        }
        
        public int GetPlinq(int from, int to)
        {
            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            
            var numbers = Enumerable.Range(@from, to - @from).AsParallel().Count(n =>
                n >= 2 && Enumerable.Range(2, (int) (Math.Sqrt(n) + 1) - 2).All(x => n > x && n % x != 0)); 

            sw.Stop();

            return numbers;
        }

        public HashSet<int> GetPrimes(int from, int to)
        {
            if (to < 0 || from > to)
            {
                return null;
            }
            
            var result = new HashSet<int>();
            for (int i = 2; i <= to; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private bool IsPrime(int number)
        {
            for (int i = 2; i < Math.Sqrt(number) + 1; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}