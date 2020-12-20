using System;
using Library;

namespace Task1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[90000];
            for(int i = accounts.Length - 1; i >= 0; i--)
            {
                accounts[i] = new Account("UAH");
            }

            QuickSort(accounts, 0, accounts.Length - 1);
            
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
        
        static void QuickSort(Account[] accounts, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(accounts, low, high);
                QuickSort(accounts, low, pi - 1);
                QuickSort(accounts, pi + 1, high);
            }
        }
        static int Partition(Account[] accounts, int low, int high)
        {
            int pivot = accounts[high].Id;
            int i = (low - 1);
            
            for (int j = low; j < high; j++)
            {
                if (accounts[j].Id < pivot)
                {
                    i++;
                    var temp = accounts[i];
                    accounts[i] = accounts[j];
                    accounts[j] = temp;
                }
            }
            
            var temp1 = accounts[i + 1];
            accounts[i + 1] = accounts[high];
            accounts[high] = temp1;
            
            return i + 1;
        }
    }
}