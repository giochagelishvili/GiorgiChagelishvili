using ToDo.Application.Subtasks.Requests;

namespace ToDo.Application.ToDos.Requests
{
    public class ToDoItemRequestPostModel
    {
        public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public List<SubtaskRequestPostModel>? Subtasks { get; set; }
    }
}
