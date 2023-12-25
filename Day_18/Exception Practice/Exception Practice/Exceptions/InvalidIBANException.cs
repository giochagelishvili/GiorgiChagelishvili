namespace Exception_Practice.Exceptions
{
    internal class InvalidIBANException : Exception
    {
        public InvalidIBANException(string? message = "Invalid IBAN operation.") : base(message)
        {
        }

        public InvalidIBANException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
