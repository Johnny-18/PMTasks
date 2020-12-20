using System;
using Library.Exceptions;

namespace Task4_1
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new LimitExceededException("LimitExceeded");
            }
            catch (InsufficientFundsException insufficientFundsException)
            {
                Console.WriteLine(insufficientFundsException.GetType());
            }
            catch (LimitExceededException limitExceededException)
            {
                Console.WriteLine(limitExceededException.GetType());
            }
            catch (PaymentServiceException paymentServiceException)
            {
                Console.WriteLine(paymentServiceException.GetType());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType());
            }

            Console.ReadLine();
        }
    }
}