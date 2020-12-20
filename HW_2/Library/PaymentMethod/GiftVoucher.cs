using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Library.AbstractClasses;
using Library.Exceptions;
using Library.Interfaces;

namespace Library.PaymentMethod
{
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        private List<decimal> usedVouchers;
        public GiftVoucher()
        {
            Name = "GiftVoucher";
            usedVouchers = new List<decimal>();
        }
        
        public void StartDeposit(decimal amount, string currency)
        {
            Console.WriteLine($"Deposit in {Name}:");
            string inputAmount;
            while (true)
            {
                Console.WriteLine("Gift certificates are available only in denominations of 100/500/1000.");
                Console.WriteLine("Enter your value:");
                inputAmount = Console.ReadLine();

                if ((inputAmount == "100" || inputAmount == "500" || inputAmount == "1000") && decimal.TryParse(inputAmount, out amount))
                    break;

                Console.WriteLine("Incorrect value!");
            }
            
            if(usedVouchers.Contains(amount))
                throw new InsufficientFundsException("No money on this voucher!", "");
            
            Regex regCard = new Regex("^\\d{10}$");
            while (true)
            {
                Console.WriteLine("Enter the card number:");
                string card = Console.ReadLine();

                if (regCard.IsMatch(card))
                    break;

                Console.WriteLine("Incorrect value! Enter card like 1010101010.");
            }
            
            usedVouchers.Add(amount);
            
            Console.WriteLine($"You’ve deposit {amount} {currency} to your card successfully");
        }
    }
}