namespace ToDo.Application.ToDos.Requests
{
    public class ToDoItemRequestPutModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int OwnerId { get; set; }
    }
}
