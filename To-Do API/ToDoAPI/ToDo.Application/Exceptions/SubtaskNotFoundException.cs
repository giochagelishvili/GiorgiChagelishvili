namespace ToDo.Application.Exceptions
{
    public class SubtaskNotFoundException : Exception
    {
        public readonly string Code = "SubtaskNotFound";

        public SubtaskNotFoundException(string message = "Subtask not found.") : base(message)
        {
        }
    }
}
