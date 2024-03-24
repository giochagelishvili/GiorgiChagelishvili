using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;
using ToDo.Domain.Users;

namespace ToDo.Domain.ToDos
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public List<Subtask>? Subtasks { get; set; }
        public int OwnerId { get; set; }

        // Navigation Property
        public User Owner { get; set; }
    }
}
