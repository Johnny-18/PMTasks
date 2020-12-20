using System;
using Library;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];
            for(int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }
            
            GetSortedAccounts(accounts);

            Console.WriteLine("First ten accounts are:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(accounts[i].Id);
            }

            Console.WriteLine("Last ten accounts are:");
            for (int i = 9; i >= 0; i--)
            {
                Console.WriteLine(accounts[accounts.Length - 1 - i].Id);
            }

            Console.ReadLine();
        }

        static void GetSortedAccounts(Account[] accounts)
        {
            bool swapped;
            for (int i = 0; i < accounts.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < accounts.Length - i - 1; j++)
                    if (accounts[j].Id > accounts[j + 1].Id)
                    {
                        var temp = accounts[j];
                        accounts[j] = accounts[j + 1];
                        accounts[j + 1] = temp;
                        swapped = true; 
                    }
                
                if (swapped == false) 
                    break;
            }
        }
    }
}