
namespace Exception_Practice.Exceptions
{
    internal class IBANDoesNotExistException : InvalidIBANException
    {
        public IBANDoesNotExistException(string? message = "IBAN doesn't exist.") : base(message)
        {
        }
    }
}
