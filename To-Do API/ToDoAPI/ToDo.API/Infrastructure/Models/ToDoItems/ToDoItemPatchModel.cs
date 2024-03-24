namespace ToDo.API.Infrastructure.Models.ToDoItems
{
    public class ToDoItemPatchModel
    {
        public string? Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
    }
}
