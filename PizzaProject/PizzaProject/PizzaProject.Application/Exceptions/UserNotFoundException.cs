using System.Security.Cryptography.X509Certificates;

namespace PizzaProject.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public readonly string Code = "UserNotFound";

        public UserNotFoundException(string message = "User not found.") : base(message)
        {
        }
    }
}
