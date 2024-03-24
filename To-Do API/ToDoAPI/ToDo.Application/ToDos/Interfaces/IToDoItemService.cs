using ToDo.Application.ToDos.Requests;
using ToDo.Application.ToDos.Responses;
using ToDo.Domain.BaseEntities;

namespace ToDo.Application.ToDos.Interfaces
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemResponseModel>> GetAllAsync(CancellationToken cancellationToken, int ownerId);
        Task<List<ToDoItemResponseModel>> GetAllAsync(CancellationToken cancellationToken, int ownerId, Status? status);
        Task<ToDoItemResponseModel> GetAsync(CancellationToken cancellationToken, int id, int ownerId);
        Task CreateAsync(CancellationToken cancellationToken, ToDoItemRequestPostModel toDoItem, int ownerId);
        Task UpdateAsync(CancellationToken cancellationToken, ToDoItemRequestPutModel toDoItem);
        Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id, int ownerId);
        Task DeleteAsync(CancellationToken cancellationToken, int id, int ownerId);
        Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId);
    }
}
