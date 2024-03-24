using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Domain.Subtasks
{
    public class Subtask : BaseEntity
    {
        public string Title { get; set; }
        public int ToDoItemId { get; set; }

        // Navigation Property
        public ToDoItem ToDoItem { get; set; }
    }
}
