namespace CompanyManagement.Application.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        public string Code = "UserUnauthorized";

        public UnauthorizedUserException(string message = "User is not authorized for this request.") : base(message) { }
    }
}
