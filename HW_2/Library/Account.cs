using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;

namespace Library
{
    public class Account
    {
        private static int _id; // static id value

        public Dictionary<string, decimal> Currencies { get; private set; }
        public int Id { get; }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        static Account()
        {
            _id = 100000;
        }

        public Account(string currency)
        {
            Currencies = new Dictionary<string, decimal>();
            Currencies.Add("EUR", (decimal)33.63);
            Currencies.Add("USD", (decimal)28.36);
            Currencies.Add("UAH", 1);

            if (CheckCurrencyOnSupported(currency))
                this.Currency = currency;
            else
                throw new NotSupportedException();
            
            Id = _id; // id generate
            _id++;
            
            Amount = 0;
        }

        public void Deposit(decimal amount, string currency)
        {
            CheckNumberOfAmount(amount);
            if(!CheckCurrencyOnSupported(currency))
                throw new NotSupportedException();

            amount = ConvertAmount(amount, currency, Currency);
            this.Amount += Math.Round(amount, 2);;
        }

        public void Withdraw(decimal amount, string currency)
        {
            CheckNumberOfAmount(amount);
            
            if(!CheckCurrencyOnSupported(currency))
                throw new NotSupportedException();
            
            if (amount > Amount)
                throw new InvalidOperationException();

            amount = ConvertAmount(amount, currency, Currency);
            Amount -= Math.Round(amount, 2);
        }

        public decimal GetBalance(string currency = null)
        {
            if (currency == null)
                return Amount;
            
            return ConvertAmount(Amount, Currency, currency);
        }
        
        public bool CheckCurrencyOnSupported(string currency)
        {
            if (string.IsNullOrEmpty(currency))
                throw new ArgumentNullException();

            return Currencies.ContainsKey(currency);
        }

        public decimal ConvertAmount(decimal amount, string fromCur, string toCurrency)
        {
            if(amount <= 0)
                throw new ArgumentException("Emount less then 0!");

            if (string.IsNullOrEmpty(fromCur) || string.IsNullOrEmpty(toCurrency))
                throw new ArgumentNullException();
            
            if (fromCur == toCurrency)
                return amount;

            amount = amount * Currencies[fromCur];

            if (Currencies[toCurrency] < Currencies[fromCur])
                return amount * Currencies[toCurrency];
            
            return amount / Currencies[toCurrency];
        }

        private bool CheckNumberOfAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount less then 0");

            return true;
        }
    }
}