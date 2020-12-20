namespace Library.Exceptions
{
    public class LimitExceededException : PaymentServiceException
    {
        public LimitExceededException()
        {
        }
        
        public LimitExceededException(string innerData) : base(innerData)
        {
        }

        public LimitExceededException(string message, string innerData) : base(message, innerData)
        {
        }
    }
}