using System;
using System.Collections.Generic;
using System.Linq;
using Library.AbstractClasses;
using Library.Exceptions;
using Library.Interfaces;
using Library.PaymentMethod;

namespace Library.Services
{
    public class PaymentService
    {
        public PaymentMethodBase[] AvailablePaymentMethod { get; private set; }

        public PaymentService()
        {
            AvailablePaymentMethod = new PaymentMethodBase[]{new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher()};
        }

        public void StartDeposit(decimal amount, string currency)
        {
            CheckOnExceptions(amount);
                
            int pay = ChoosePayMethod();

            var method = (ISupportDeposit)AvailablePaymentMethod[pay];
            method.StartDeposit(amount, currency);
        }

        public void StartWithdrawal(decimal amount, string currency)
        {
            CheckOnExceptions(amount);
            
            int pay = ChoosePayMethod(true);

            var method = (ISupportWithdrawal)AvailablePaymentMethod[pay];
            method.StartWithdrawal(amount, currency);
        }

        private int ChoosePayMethod(bool isWithdraw = false)
        {
            int pay;
            string typeName;

            if (isWithdraw)
            {
                typeName = "ISupportWithdrawal";
            }
            else
            {
                typeName = "ISupportDeposit";
            }
            
            for (;;)
            {
                int j = 0;
                List<int> entryIndex = new List<int>();

                Console.WriteLine("Choose withdraw method:");
                foreach (var payMethod in AvailablePaymentMethod)
                {

                    if(payMethod.GetType().GetInterfaces().Any(a => a.Name == typeName))
                    {
                        Console.WriteLine($"{j} {payMethod.Name}");
                        entryIndex.Add(j);
                    }

                    j++;
                }

                string payMeth = Console.ReadLine();
                if (int.TryParse(payMeth, out pay) && entryIndex.Contains(pay))
                    break;

                Console.WriteLine("Incorrect value!");
            }

            return pay;
        }
        
        private void CheckOnExceptions(decimal amount)
        {
            if(new Random().Next(0, 100) < 3)
                throw new PaymentServiceException("Unknown error inside the system!");
        }
    }
}