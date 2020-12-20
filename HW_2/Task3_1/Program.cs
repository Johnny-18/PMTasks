using System;
using Library;
using Library.PaymentMethod;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            creditCard.StartDeposit(50, "USD");
            creditCard.StartDeposit(50, "USD");
            
            creditCard.StartWithdrawal(50, "USD");
            
            Privet48 privet48 = new Privet48();
            privet48.StartDeposit(50, "USD");
            
            Stereobank stereobank = new Stereobank();
            stereobank.StartWithdrawal(50, "USD");
            
            GiftVoucher giftVoucher = new GiftVoucher();
            giftVoucher.StartDeposit(50, "USD");
            giftVoucher.StartDeposit(500, "USD");
            giftVoucher.StartDeposit(500, "USD");
            
        }
    }
}