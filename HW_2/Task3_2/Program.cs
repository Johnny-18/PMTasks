using System;
using Library;
using Library.Services;

namespace Task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService service = new PaymentService();
            service.StartDeposit(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartDeposit(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartWithdrawal(50, "USD");
            service.StartDeposit(50, "USD");
            service.StartDeposit(50, "USD");
            service.StartDeposit(50, "USD");
            Console.ReadLine();
        }
    }
}