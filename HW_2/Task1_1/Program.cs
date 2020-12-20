using System;
using System.Collections.Generic;
using Library;

namespace Task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acUsd = new Account("USD");
            Account acUah = new Account("UAH");
            Account acEur = new Account("EUR");
            
            acEur.Deposit(10, "EUR");
            acEur.Withdraw(3, "UAH");
            
            acUah.Deposit(121, "USD");

            try
            {
                acUsd.Withdraw(5, "USD");
            }
            catch(InvalidOperationException invalidOperationException)
            {
            }

            try
            {
                Account acPln = new Account("PLN");
            }
            catch(NotSupportedException e)
            {
            }
            
            List<Account> accounts = new List<Account>();
            accounts.Add(acUah);
            accounts.Add(acUsd);
            accounts.Add(acEur);

            foreach (var acc in accounts)
            {
                Console.WriteLine($"Account with currency {acc.Currency} has {acc.GetBalance()} balance.");
            }

            Console.ReadLine();
        }
    }
}