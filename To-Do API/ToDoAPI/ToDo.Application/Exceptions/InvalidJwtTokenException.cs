namespace ToDo.Application.Exceptions
{
    public class InvalidJwtTokenException : Exception
    {
        public readonly string Code = "InvalidJwtToken";

        public InvalidJwtTokenException(string message = "Invalid JWT token.") : base(message)
        {
        }
    }
}
