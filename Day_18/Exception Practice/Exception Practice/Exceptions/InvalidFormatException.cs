namespace Exception_Practice.Exceptions
{
    internal class InvalidFormatException : InvalidAmountException
    {
        public InvalidFormatException(string message = "Please provide amount in numbers.") : base(message) { }
    }
}
