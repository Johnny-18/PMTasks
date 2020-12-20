using System;
using System.Security;

namespace Library
{
    public class Player
    {
        private static int _id;
        
        public int Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        
        private Account _account;

        static Player()
        {
            _id = 100000;
        }

        public Player(string firstName, string lastName, string email, string password, string currency)
        {
            Id = _id; // id generate
            _id++;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
                throw new ArgumentNullException();

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            
            _account = new Account(currency);
        }

        public bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            return Password == password;
        }

        public void Deposit(decimal amount, string Currency)
        {
            _account.Deposit(amount, Currency);
        }

        public void Withdraw(decimal amount, string Currency)
        {
            _account.Withdraw(amount, Currency);
        }
    }
}