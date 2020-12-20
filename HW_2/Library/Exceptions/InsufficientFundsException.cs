namespace Library.Exceptions
{
    public class InsufficientFundsException : PaymentServiceException
    {
        public InsufficientFundsException()
        {
        }
        
        public InsufficientFundsException(string innerData) : base(innerData)
        {
        }

        public InsufficientFundsException(string message, string innerData) : base(message, innerData)
        {
        }
    }
}