namespace Exception_Practice.Exceptions
{
    internal class InsufficientFundsException : InvalidAmountException
    {
        public InsufficientFundsException(string message = "Insufficient funds.") : base(message) { }
    }
}
