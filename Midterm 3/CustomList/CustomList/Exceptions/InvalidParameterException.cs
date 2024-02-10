namespace CustomList.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string? message = "Invalid parameter type provided.") : base(message)
        {
        }
    }
}
