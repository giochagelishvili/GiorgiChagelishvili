using ToDo.Application.Subtasks.Responses;
using ToDo.Domain.BaseEntities;

namespace ToDo.Application.ToDos.Responses
{
    public class ToDoItemResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public List<SubtaskResponseModel>? Subtasks { get; set; }
    }
}
