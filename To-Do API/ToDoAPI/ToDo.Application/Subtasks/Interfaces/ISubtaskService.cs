using ToDo.Application.Subtasks.Requests;
using ToDo.Domain.BaseEntities;

namespace ToDo.Application.Subtasks.Interfaces
{
    public interface ISubtaskService
    {
        Task CreateAsync(CancellationToken cancellationToken, SubtaskRequestPostModel subtask, int ownerId);
        Task UpdateAsync(CancellationToken cancellationToken, SubtaskRequestPutModel subtask, int ownerId);
        Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id, int ownerId);
        Task DeleteAsync(CancellationToken cancellationToken, int id, int ownerId);
    }
}
