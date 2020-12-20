using System;
using System.Text.RegularExpressions;
using Library.AbstractClasses;
using Library.Exceptions;
using Library.Interfaces;

namespace Library.PaymentMethod
{
    public class CreditCard : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "CreditCard";
        }

        public void StartDeposit(decimal amount, string currency)
        {
            CheckOnExceptions(amount);

            Regex card = new Regex("^[4-5]\\d\\d\\d \\d\\d\\d\\d \\d\\d\\d\\d \\d\\d\\d\\d$");
            Regex regexDate = new Regex("^\\d\\d/\\d\\d$");
            Regex regexCvv = new Regex("^\\d\\d\\d$");

            string cardNumber, date, cvv;
            
            Console.WriteLine($"Deposit in {Name}:");

            while (true)
            {
                Console.WriteLine("Enter your credit card number:");
                cardNumber = Console.ReadLine();

                if (card.IsMatch(cardNumber))
                    break;

                Console.WriteLine("Incorrect value, enter in format 4444 4444 4444 4444!");
            }

            while (true)
            {
                Console.WriteLine("Enter expiry date:");
                date = Console.ReadLine();

                if (regexDate.IsMatch(date))
                    break;
                
                Console.WriteLine("Incorrect value, enter in format 12/12!");
            }

            while (true)
            {
                Console.WriteLine("Enter CVV:");
                cvv = Console.ReadLine();

                if (regexCvv.IsMatch(cvv))
                    break;
                
                Console.WriteLine("Incorrect value, enter in format 123!");
            }

            Console.WriteLine($"You’ve deposit {amount} {currency} to your {cardNumber} card successfully");
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            CheckOnExceptions(amount);
            
            Regex card = new Regex("^[4-5]\\d\\d\\d \\d\\d\\d\\d \\d\\d\\d\\d \\d\\d\\d\\d$");
            string cardNumber;

            Console.WriteLine($"Withdraw in {Name}:");
            while (true)
            {
                Console.WriteLine("Enter your credit card number:");
                cardNumber = Console.ReadLine();

                if (card.IsMatch(cardNumber))
                {
                    break;
                }

                Console.WriteLine("Incorrect value, enter in format 4444 4444 4444 4444!");
            }
            
            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {cardNumber} card successfully");
        }

        private void CheckOnExceptions(decimal amount)
        {
            if(amount > 3000)
                throw new LimitExceededException("Internet limit is 3000!", "innerData");
        }
    }
}