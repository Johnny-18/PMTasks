using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Library.Exceptions;
using Library.Services;

namespace Library.ChatBot
{
    public class BettingPlatformEmulator
    {
        private List<Player> _players;
        private Player _activePlayer;
        private Account _account;
        private PaymentService _paymentService;
        private BetService _service;

        public BettingPlatformEmulator()
        {
            _account = new Account("USD");
            _players = new List<Player>();
            _service = new BetService();
            _paymentService = new PaymentService();
            _activePlayer = null;
        }

        public void Start()
        {
            while (true)
            {
                if (_activePlayer == null)
                {
                    Console.Clear();
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");
                    
                    Console.WriteLine("Enter your action:");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Register();
                            break;
                        case "2":
                            Login();
                            break;
                        case "3":
                            Exit();
                            break;
                        default:
                            PressContinue("Enter correct message!");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Player menu:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. GetOdds");
                    Console.WriteLine("4. Bet");
                    Console.WriteLine("5. Logout");
                    
                    Console.WriteLine("Enter your action:");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Deposit();
                            break;
                        case "2":
                            Withdraw();
                            break;
                        case "3":
                            GetOdds();
                            break;
                        case "4":
                            Bet();
                            break;
                        case "5":
                            Logout();
                            break;
                        default:
                            PressContinue("Enter correct message!");
                            break;
                    }
                }
            }
        }

        private void Bet()
        {
            Console.Clear();
            Console.WriteLine("Bet menu:");
            
            decimal amount = GetAmount();
            string currency = GetCurrency();
            
            try
            {
                _activePlayer.Withdraw(amount, currency);
            }
            catch
            {
                PressContinue("There is insufficient funds on your account");
                return;
            }

            var convertedToUsd = _account.ConvertAmount(Convert.ToDecimal(amount), currency, _account.Currency);
            var result = _service.Bet(convertedToUsd);

            if (result != 0)
            {
                try
                {
                    _account.Withdraw(amount, currency);
                }
                catch
                {
                    PressContinue("There is some problem on the platform side. Please try it later");
                    return;
                }
                
                _activePlayer.Deposit(result, currency);
                Console.WriteLine($"You won {result} {_account.Currency}");
            }
            else
            {
                _account.Deposit(amount, currency);
                Console.WriteLine("You lose");
            }
            
            PressContinue(string.Empty);
        }

        private void GetOdds()
        {
            Console.Clear();
            Console.Write("\nCurrent odd: ");
            Console.Write(Math.Round(_service.GetOdd(), 2));
            PressContinue(string.Empty);
        }

        private void Login()
        {
            Console.Clear();
            Console.WriteLine("Login:");

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            var currentPlayer = _players.FindLast(x => x.Email == email && x.IsPasswordValid(password));
            if (currentPlayer == null)
            {
                PressContinue("User not found!");
            }
            else
                _activePlayer = currentPlayer;
        }

        private void Logout()
        {
            _activePlayer = null;
        }

        private void Deposit()
        {
            Console.Clear();
            Console.WriteLine("Deposit menu:");
            
            decimal amount = GetAmount();
            string currency = GetCurrency();

            try
            {
                _paymentService.StartDeposit(amount, currency);
            }
            catch (InsufficientFundsException insufficientFundsException)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount");
            }
            catch (LimitExceededException limitExceededException)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount or change the payment method");
            }
            catch (PaymentServiceException paymentServiceException)
            {
                Console.WriteLine("Something went wrong. Try again later...");
            }

            try
            {
                _activePlayer.Deposit(amount, currency);
                _account.Deposit(amount, currency);
            }
            catch (ArgumentException e)
            {
                PressContinue(e.Message);
            }
            catch (NotSupportedException e)
            {
                PressContinue(e.Message);
            }
            catch
            {
                PressContinue("Something going wrong!");
            }
        }

        private void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Withdraw menu:");
            
            decimal amount = GetAmount();
            string currency = GetCurrency();

            try
            {
                _paymentService.StartWithdrawal(amount, currency);
            }
            catch (InsufficientFundsException insufficientFundsException)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount");
            }
            catch (LimitExceededException limitExceededException)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount or change the payment method");
            }
            catch (PaymentServiceException paymentServiceException)
            {
                Console.WriteLine("Something went wrong. Try again later...");
            }

            try
            {
                _account.Withdraw(amount, currency);
            }
            catch
            {
                PressContinue("There is some problem on the platform side. Please try it later");
                return;
            }

            try
            {
                _activePlayer.Withdraw(amount, currency);
            }
            catch
            {
                PressContinue("There is insufficient funds on your account");
            }
        }

        private string GetCurrency()
        {
            string currency = "";
            while (true)
            {
                Console.WriteLine("Enter currency:");
                currency = Console.ReadLine();
                try
                {
                    if (_account.CheckCurrencyOnSupported(currency))
                        break;
                }
                catch
                {
                    Console.WriteLine("Value is empty!");
                }

                Console.WriteLine("Invalid value!");
                Console.Write("Supported currencies:");
                foreach (var cur in _account.Currencies)
                {
                    Console.Write(" " + cur.Key);                    
                }
                Console.WriteLine();
            }

            return currency;
        }

        private decimal GetAmount()
        {
            decimal amountNumber = 0;
            while (true)
            {
                Console.WriteLine("Enter amount:");
                string amount = Console.ReadLine();

                if (decimal.TryParse(amount, out amountNumber) && amountNumber >= 0)
                    break;

                Console.WriteLine("Invalid value! Amount must be decimal number and above zero!");
            }

            return amountNumber;
        }

        private void Register()
        {
            Console.Clear();
            Console.WriteLine("Register menu:");

            string firstName, lastName, email;
            Regex names = new Regex("[A-Z][a-z]+");
            Regex regexEmail = new Regex("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            
            while (true)
            {
                Console.WriteLine("Enter your firstname:");
                firstName = Console.ReadLine();

                if (names.IsMatch(firstName))
                    break;

                Console.WriteLine("Incorrect value!");
            }

            while (true)
            {
                Console.WriteLine("Enter your lastname:");
                lastName = Console.ReadLine();

                if (names.IsMatch(lastName))
                    break;
                
                Console.WriteLine("Incorrect value!");
            }

            while (true)
            {
                Console.WriteLine("Enter your email:");
                email = Console.ReadLine();
                
                if (regexEmail.IsMatch(email))
                    break;
                
                Console.WriteLine("Incorrect value!");
            }

            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            string currency = GetCurrency();
            
            Player newPlayer = new Player(firstName, lastName, email, password, currency);
            _players.Add(newPlayer);
        }

        private void Exit()
        {
            Environment.Exit(1);
        }

        private void PressContinue(string text)
        {
            if(!string.IsNullOrEmpty(text))
                Console.WriteLine(text);
            
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
        }
        
    }
}