using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;

namespace ToDo.Application.Subtasks.Interfaces
{
    public interface ISubtaskRepository
    {
        Task<List<Subtask>> GetAllAsync(CancellationToken cancellationToken, int toDoItemId);
        Task<Subtask?> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Subtask subtask);
        Task UpdateAsync(CancellationToken cancellationToken, Subtask subtask);
        Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId);
    }
}
