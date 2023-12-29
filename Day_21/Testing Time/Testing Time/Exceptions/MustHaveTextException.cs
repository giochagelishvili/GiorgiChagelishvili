namespace Testing_Time.Exceptions
{
    internal class MustHaveTextException : Exception
    {
        public MustHaveTextException(string? message = "Please provide the text.") : base(message)
        {
        }
    }
}
