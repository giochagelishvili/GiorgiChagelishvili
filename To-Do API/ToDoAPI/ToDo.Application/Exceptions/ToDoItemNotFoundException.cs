namespace ToDo.Application.Exceptions
{
    public class ToDoItemNotFoundException : Exception
    {
        public readonly string Code = "ToDoItemNotFound";

        public ToDoItemNotFoundException(string message = "To do item not found") : base(message)
        {
        }
    }
}
