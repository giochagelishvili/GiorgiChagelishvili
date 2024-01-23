namespace Practice.Exceptions
{
    internal class InvalidSearchInputException : Exception
    {
        public InvalidSearchInputException(string? message = "Invalid search input.") : base(message)
        {
        }
    }
}
