using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos.Interfaces
{
    public interface IToDoItemRepository
    {
        Task<List<ToDoItem>> GetAllAsync(CancellationToken cancellationToken, int ownerId);
        Task<List<ToDoItem>> GetAllByStatusAsync(CancellationToken cancellationToken, int ownerId, Status? status);
        Task<ToDoItem?> GetAsync(CancellationToken cancellationToken, int id, int ownerId);
        Task CreateAsync(CancellationToken cancellationToken, ToDoItem toDoItem);
        Task UpdateAsync(CancellationToken cancellationToken, ToDoItem toDoItem);
        Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId);
    }
}
