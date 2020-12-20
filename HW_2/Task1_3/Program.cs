using System;
using Library;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 1000000;
            Account[] accounts = new Account[length];
            for(int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }

            GetSortedAccounts(accounts);
            
            int id = 0;
            Console.WriteLine("Enter id to find element:");
            id = Convert.ToInt32(Console.ReadLine());

            int attempts = 0;

            int index = BinarySearch(accounts, id, ref attempts);
            if(index == -1)
                Console.WriteLine($"There is no account {id} in the list");
            else
                Console.WriteLine($"{id} was found at index {index} by {attempts} tries");
            Console.ReadLine();
        }

        static int BinarySearch(Account[] accounts, int id, ref int attempts)
        {
            attempts = 0;
            int left = 0, right = accounts.Length - 1;
            while (left <= right)
            {
                attempts++;
                int middle = left + (right - left) / 2;
                
                if (accounts[middle].Id == id) 
                    return middle; 

                if (accounts[middle].Id < id) 
                    left = middle + 1;
                else
                    right = middle - 1; 
            }
            
            return -1; 
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