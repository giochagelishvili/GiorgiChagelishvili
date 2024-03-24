namespace ToDo.API.Infrastructure.Models.ToDoItems
{
    public class ToDoItemPutModel
    {
        public string Title { get; set; }
        public DateTime TargetCompletionDate { get; set; }
    }
}
