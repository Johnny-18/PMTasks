using System;
using Library.Services;

namespace Library.Menu
{
    public class ConverterMenu
    {
        private readonly ConverterService _service;

        public ConverterMenu()
        {
            _service = new ConverterService();
        }
        public void Start()
        {
            Console.WriteLine("Program for convert currency.");
            Console.WriteLine("Created by Ivan Zherybor.");

            string fromCurrency;
            string toCurrency;
            string amountStr;
            decimal amount;

            for (;;)
            {
                Console.WriteLine("Enter exit to stop program!");
                fromCurrency = EnterCurrency("Enter the original currency, 3 symbols:");
                if (fromCurrency == null)
                    return;
                
                toCurrency = EnterCurrency("Enter the desired currency, 3 symbols:");
                if (toCurrency == null)
                    return;

                for (;;)
                {
                    Console.WriteLine("Enter your amount:");
                    amountStr = Console.ReadLine();
                    if (amountStr == "exit")
                        return;
                    
                    if (decimal.TryParse(amountStr, out amount))
                    {
                        break;
                    }

                    Console.WriteLine("Enter correct number!");
                }

                _service.Convert(fromCurrency, toCurrency, amount);
            }
        }

        private string EnterCurrency(string message)
        {
            for (;;)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                if (input == "exit")
                    return null;

                if (string.IsNullOrEmpty(input) || input.Length > 3)
                {
                    Console.WriteLine("Enter correct currency, currency have 3 symbols!");
                    continue;
                }

                return input;
            }
        }
    }
}