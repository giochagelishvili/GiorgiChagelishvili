namespace ToDo.Application.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public readonly string Code = "InvalidParameter";

        public InvalidParameterException(string message = "Invalid parameter.") : base(message)
        {
        }
    }
}
