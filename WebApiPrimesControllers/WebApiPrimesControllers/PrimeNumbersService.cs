using System;
using System.Collections.Generic;

namespace WebApiPrimesControllers
{
    public class PrimeNumbersService
    {
        public bool IsPrime(int number)
        {
            for (int i = 2; i < Math.Sqrt(number) + 1; i++)
            {
                if (number % i == 0 && number != i)
                    return false;
            }

            return true;
        }

        public IEnumerable<int> GetPrimes(int from, int to)
        {
            if (to < 0 || from > to)
            {
                return null;
            }

            if (from <= 2)
            {
                from = 2;
            }
            
            var result = new List<int>();
            for (int i = from; i <= to; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}