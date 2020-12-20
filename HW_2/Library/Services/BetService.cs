using System;

namespace Library.Services
{
    public class BetService
    {
        private decimal _odd; // coef, can be in range from 1.01 to 25.00

        public BetService()
        {
            Random randomValue = new Random();
            _odd = Convert.ToDecimal(randomValue.Next(1,25) + (double)randomValue.Next(0, 101)/100);
        }

        public decimal GetOdd()
        {
            return _odd;
        }

        public float GetOdds()
        {
            Random randomValue = new Random();
            _odd = Convert.ToDecimal(randomValue.Next(1,25) + (double)randomValue.Next(1,101)/100);

            return (float)_odd;
        }

        public bool IsWon()
        {
            var percent = Math.Round(100 / _odd, 2);
            
            Random random = new Random();
            var randomValue = random.Next(0, 101);
            
            if (randomValue < percent)
                return true;

            return false;
        }

        public decimal Bet(decimal amount)
        {
            if (!IsWon())
            {
                return _odd * amount;
            }

            return 0;
        }
    }
}