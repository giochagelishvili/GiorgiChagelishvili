using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Domain.Users
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Navigation Property
        public List<ToDoItem>? ToDoItems { get; set; }
    }
}
