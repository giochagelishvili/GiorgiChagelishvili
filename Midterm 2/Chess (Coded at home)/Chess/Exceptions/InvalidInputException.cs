namespace Chess.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string? message = "Invalid input provided.") : base(message)
        {
        }
    }
}
