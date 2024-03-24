using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.ToDos.Interfaces;
using ToDo.Application.ToDos.Requests;
using ToDo.Application.ToDos.Responses;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;

namespace ToDo.Application.ToDos
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _repository;

        public ToDoItemService(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDoItemResponseModel>> GetAllAsync(CancellationToken cancellationToken, int ownerId)
        {
            var result = await _repository.GetAllAsync(cancellationToken, ownerId);

            if (result == null || result.Count <= 0)
                throw new ToDoItemNotFoundException();

            return result.Adapt<List<ToDoItemResponseModel>>();
        }

        public async Task<List<ToDoItemResponseModel>> GetAllAsync(CancellationToken cancellationToken, int ownerId, Status? status)
        {
            if (status == Status.Deleted)
                throw new ForbiddenOperationException();
            else if (status != Status.Active && status != Status.Done)
                throw new InvalidParameterException();

            var result = await _repository.GetAllByStatusAsync(cancellationToken, ownerId, status);

            if (result == null || result.Count <= 0)
                throw new ToDoItemNotFoundException();

            return result.Adapt<List<ToDoItemResponseModel>>();
        }

        public async Task<ToDoItemResponseModel> GetAsync(CancellationToken cancellationToken, int id, int ownerId)
        {
            var result = await _repository.GetAsync(cancellationToken, id, ownerId);

            if (result == null)
                throw new ToDoItemNotFoundException();

            return result.Adapt<ToDoItemResponseModel>();
        }

        public async Task CreateAsync(CancellationToken cancellationToken, ToDoItemRequestPostModel toDoItem, int ownerId)
        {
            var entity = toDoItem.Adapt<ToDoItem>();

            entity.OwnerId = ownerId;

            await _repository.CreateAsync(cancellationToken, entity);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ToDoItemRequestPutModel toDoItem)
        {
            if (!await Exists(cancellationToken, toDoItem.Id, toDoItem.OwnerId))
                throw new ToDoItemNotFoundException();

            var entity = toDoItem.Adapt<ToDoItem>();

            await _repository.UpdateAsync(cancellationToken, entity);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id, int ownerId)
        {
            if (!await Exists(cancellationToken, id, ownerId))
                throw new ToDoItemNotFoundException();
            else if (status != Status.Done)
                throw new InvalidOperationException();

            await _repository.UpdateStatusAsync(cancellationToken, status, id);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id, int ownerId)
        {
            if (!await Exists(cancellationToken, id, ownerId))
                throw new ToDoItemNotFoundException();

            await _repository.DeleteAsync(cancellationToken, id);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId)
        {
            return await _repository.Exists(cancellationToken, id, ownerId);
        }
    }
}
