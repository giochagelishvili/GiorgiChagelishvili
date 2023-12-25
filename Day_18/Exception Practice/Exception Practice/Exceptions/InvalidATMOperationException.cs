namespace Exception_Practice.Exceptions
{
    public class InvalidATMOperationException : Exception
    {
        public InvalidATMOperationException(string message = "Please choose one of listed operations.") : base(message)
        {
        }
    }
}
