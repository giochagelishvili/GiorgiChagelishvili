namespace ToDo.Application.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public readonly string Code ="InvalidEntity";

        public InvalidEntityException(string message = "Invalid entity") : base(message)
        {
        }
    }
}
