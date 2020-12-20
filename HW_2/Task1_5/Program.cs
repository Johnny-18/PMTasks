using System;
using Library;

namespace Task1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "password";
            Player player = new Player("John Doe", "Betman", "john@gmail.com", password, "USD");

            string badPass = "pass";
            
            Console.WriteLine($"Login with login {player.Email} and password {badPass} is {player.IsPasswordValid(badPass)}");
            Console.WriteLine($"Login with login {player.Email} and password {password} is {player.IsPasswordValid(password)}");
            
            player.Deposit(100, "USD");
            player.Withdraw(50, "EUR");

            try
            {
                player.Withdraw(1000, "USD");
            }
            catch
            {
                
            }

            try
            {
                Player player1 = new Player("John Doe", "Betman", "john@gmail.com", password, "PLN");
            }
            catch 
            {
            }
            
            Console.ReadLine();
        }
    }
}