using System;

namespace WebPrimesNumbers.Services
{
    public class PrimeNumbersService
    {
        public bool IsPrime(int number)
        {
            for (int i = 2; i < Math.Sqrt(number) + 1; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public int[] PrimesInRange(int from, int to)
        {
            return null;
        }
    }
}