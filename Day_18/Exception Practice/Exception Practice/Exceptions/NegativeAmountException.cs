namespace Exception_Practice.Exceptions
{
    internal class NegativeAmountException : InvalidAmountException
    {
        public NegativeAmountException(string message = "Amount must be more than $0.") : base(message) { }
    }
}
