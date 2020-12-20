using System;
using System.IO;

namespace Library.Exceptions
{
    public class PaymentServiceException : ArgumentException
    {
        private readonly string _innerData;

        public PaymentServiceException() : base("Not allowed payment")
        {
            _innerData = string.Empty;
        }
        
        public PaymentServiceException(string innerData) : this("Not allowed payment", innerData)
        {
        }

        public PaymentServiceException(string message, string innerData) : base(message)
        {
            _innerData = innerData;
        }
    }
}