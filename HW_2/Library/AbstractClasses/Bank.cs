using System;
using Library.Exceptions;
using Library.Interfaces;

namespace Library.AbstractClasses
{
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        protected decimal amountTransaction = 0;
        public string[] AvailableCards { get; protected set; }

        public Bank()
        {
            AvailableCards = new string[2] {"4321 4321 4321 4321", "5432 5432 5432 5432"};
        }

        public void StartDeposit(decimal amount, string currency)
        {
            CheckOnExceptions(amount);
            
            Console.WriteLine($"Deposit:");
            var cardAsNumber = Login();

            Console.WriteLine($"You’ve deposit {amount} {currency} to your {AvailableCards[Convert.ToInt32(cardAsNumber)]} card successfully");
            amountTransaction += amount;
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            CheckOnExceptions(amount);
            
            Console.WriteLine("Withdraw:");
            var cardAsNumber = Login();

            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {AvailableCards[Convert.ToInt32(cardAsNumber)]} card successfully");
            amountTransaction += amount;
        }

        private int Login()
        {
            Console.WriteLine($"Welcome, dear client, to the online bank {Name}");
            
            string login;
            while (true)
            {
                Console.WriteLine("Please, enter your login");
                login = Console.ReadLine();

                if (!string.IsNullOrEmpty(login))
                    break;

                Console.WriteLine("Values must not be empty!");
            }

            string password;
            while (true)
            {
                Console.WriteLine("Please, enter your password");
                password = Console.ReadLine();
                
                if (!string.IsNullOrEmpty(password))
                    break;
                
                Console.WriteLine("Values must not be empty!");
            }

            if (AvailableCards == null)
            {
                Console.WriteLine("Hello Mr {login}. You don't have cards.");
                return -1;
            }
            
            Console.WriteLine($"Hello Mr {login}. Pick a card to proceed the transaction:");

            int cardAsNumber;
            while (true)
            {
                Console.WriteLine("Enter card:");
                
                for (int i = 0; i < AvailableCards.Length; i++)
                {
                    Console.WriteLine($"{i} {AvailableCards[i]}");
                }
                
                string card = Console.ReadLine();
                if (int.TryParse(card, out cardAsNumber) && cardAsNumber < AvailableCards.Length)
                    break;

                Console.WriteLine("Incorrect value!");
            }

            return cardAsNumber;
        }

        private void CheckOnExceptions(decimal amount)
        {
            if(Name == "Privet48" && amountTransaction > 10000)
                throw new LimitExceededException("Transaction limit is 10000!", "");
            
            if(Name == "Stereobank" && amountTransaction > 7000)
                throw new LimitExceededException("Transaction limit is 7000!", "");
            
            if(Name == "Stereobank" && amount > 3000)
                throw new LimitExceededException("Internet transaction limit is 3000", "");
        }
    }
}