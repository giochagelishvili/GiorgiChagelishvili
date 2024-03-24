using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.Subtasks.Interfaces;
using ToDo.Application.Subtasks.Requests;
using ToDo.Application.ToDos.Interfaces;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;

namespace ToDo.Application.Subtasks
{
    public class SubtaskService : ISubtaskService
    {
        private readonly ISubtaskRepository _subtaskRepository;
        private readonly IToDoItemRepository _toDoItemRepository;

        public SubtaskService(ISubtaskRepository repository, IToDoItemRepository toDoItemRepository)
        {
            _subtaskRepository = repository;
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, SubtaskRequestPostModel subtask, int ownerId)
        {
            if (!await _toDoItemRepository.Exists(cancellationToken, subtask.ToDoItemId, ownerId))
                throw new ToDoItemNotFoundException();

            var entity = subtask.Adapt<Subtask>();

            await _subtaskRepository.CreateAsync(cancellationToken, entity);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, SubtaskRequestPutModel subtask, int ownerId)
        {
            if (!await _subtaskRepository.Exists(cancellationToken, subtask.Id, ownerId))
                throw new SubtaskNotFoundException();

            var entity = subtask.Adapt<Subtask>();

            await _subtaskRepository.UpdateAsync(cancellationToken, entity);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id, int ownerId)
        {
            if (!await _subtaskRepository.Exists(cancellationToken, id, ownerId))
                throw new SubtaskNotFoundException();

            await _subtaskRepository.DeleteAsync(cancellationToken, id);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id, int ownerId)
        {
            if (!await _subtaskRepository.Exists(cancellationToken, id, ownerId))
                throw new SubtaskNotFoundException();

            if (status != Status.Active && status != Status.Done)
                throw new InvalidParameterException();

            await _subtaskRepository.UpdateStatusAsync(cancellationToken, status, id);
        }
    }
}
