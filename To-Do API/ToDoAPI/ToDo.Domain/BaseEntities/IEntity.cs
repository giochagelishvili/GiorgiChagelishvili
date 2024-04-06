using ToDo.Domain.ToDos;

namespace ToDo.Domain.BaseEntities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        Status Status { get; set; }
    }

    public enum Status
    {
        Active = 1,
        Done = 2,
        Deleted = 3
    }
}
