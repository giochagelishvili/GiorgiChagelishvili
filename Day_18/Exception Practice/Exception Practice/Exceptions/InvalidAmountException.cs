namespace Exception_Practice.Exceptions
{
    internal class InvalidAmountException : Exception
    {
        public InvalidAmountException(string? message = "There was a problem with provided amount.") : base(message)
        {
        }

        public InvalidAmountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
