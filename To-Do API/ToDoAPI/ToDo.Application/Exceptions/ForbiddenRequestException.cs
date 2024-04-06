namespace ToDo.Application.Exceptions
{
    public class ForbiddenOperationException : Exception
    {
        public readonly string Code = "ForbiddenOperation";

        public ForbiddenOperationException(string message = "This operation is forbidden.") : base(message)
        {
        }
    }
}
