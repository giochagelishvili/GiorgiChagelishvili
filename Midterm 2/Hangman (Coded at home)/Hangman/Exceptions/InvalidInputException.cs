namespace Hangman.Exceptions
{
    internal class InvalidInputException : Exception
    {
        public InvalidInputException(string? message = "Invalid input.") : base(message)
        {
        }
    }
}
