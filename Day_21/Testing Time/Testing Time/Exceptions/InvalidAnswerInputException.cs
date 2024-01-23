namespace Testing_Time.Exceptions
{
    internal class InvalidAnswerInputException : Exception
    {
        public InvalidAnswerInputException(string? message = "Please choose A, B, C or D.") : base(message)
        {
        }
    }
}
