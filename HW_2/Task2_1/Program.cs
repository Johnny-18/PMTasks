using System;
using Library;
using Library.Services;

namespace Task2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = 100;
            BetService service = new BetService();
            for (int i = 0; i < 10; i++)
            {
                var winAmount = service.Bet(amount);
               Console.WriteLine($"I’ve bet {amount} USD with the odd {service.GetOdd()} and I’ve earned {winAmount}");
                service.GetOdds();
            }

            for (int i = 0; i < 3;)
            {
                service.GetOdds();
                if (service.GetOdd() > 12)
                {
                    var winAmount = service.Bet(amount);
                    Console.WriteLine(
                        $"I’ve bet 100 USD with the odd {service.GetOdd()} and I’ve earned {winAmount}");
                    i++;
                }
            }

            decimal startAmount = 10000;
            while (startAmount > 0 && startAmount < 150000)
            {
                if (service.GetOdd() > 20)
                {
                    var monForBet = 1000;
                    if (startAmount < 1000)
                        break;
                    startAmount -= monForBet;
                    startAmount += service.Bet(monForBet);
                }
                
                if (service.GetOdd() > 10)
                {
                    var monForBet = 100;
                    if (startAmount < 100)
                        break;
                    startAmount -= monForBet;
                    startAmount += service.Bet(monForBet);
                }

                if (startAmount < 100)
                {
                    var monForBet = startAmount;
                    startAmount = 0;
                    startAmount += service.Bet(monForBet);
                }
            }
            Console.WriteLine($"Game over. My balance is {startAmount}");
            Console.ReadLine();
        }
    }
}