namespace ToDo.Application.Exceptions
{
    public class InvalidClaimException : Exception
    {
        public readonly string Code = "InvalidClaim";

        public InvalidClaimException(string message = "Claim is missing or invalid.") : base(message)
        {
        }
    }
}
