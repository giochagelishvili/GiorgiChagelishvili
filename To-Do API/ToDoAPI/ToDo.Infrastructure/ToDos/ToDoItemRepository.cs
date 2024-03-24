using Microsoft.EntityFrameworkCore;
using ToDo.Application.ToDos.Interfaces;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.ToDos;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.ToDos
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<List<ToDoItem>> GetAllAsync(CancellationToken cancellationToken, int ownerId)
        {
            return await _context.Set<ToDoItem>()
                                 .Where(toDoItem => toDoItem.OwnerId == ownerId && (toDoItem.Status == Status.Active || toDoItem.Status == Status.Done))
                                 .Include(toDoItem => toDoItem.Subtasks)
                                 .ToListAsync(cancellationToken);
        }

        public async Task<List<ToDoItem>> GetAllByStatusAsync(CancellationToken cancellationToken, int ownerId, Status? status)
        {
            return await _context.Set<ToDoItem>()
                                 .Where(toDoItem => toDoItem.OwnerId == ownerId && toDoItem.Status == status)
                                 .Include(toDoItem => toDoItem.Subtasks)
                                 .ToListAsync(cancellationToken);
        }

        public async Task<ToDoItem?> GetAsync(CancellationToken cancellationToken, int id, int ownerId)
        {
            return await _context.Set<ToDoItem>()
                                 .Include(toDoItem => toDoItem.Subtasks)
                                 .FirstOrDefaultAsync(toDoItem => toDoItem.Id == id && toDoItem.OwnerId == ownerId && (toDoItem.Status == Status.Active || toDoItem.Status == Status.Done), cancellationToken);
        }

        public new async Task UpdateAsync(CancellationToken cancellationToken, ToDoItem toDoItem)
        {
            var result = await GetAsync(cancellationToken, toDoItem.Id, toDoItem.OwnerId);

            if (toDoItem.Title != null)
                result.Title = toDoItem.Title;

            if (toDoItem.TargetCompletionDate != null)
                result.TargetCompletionDate = toDoItem.TargetCompletionDate;

            _dbSet.Update(result);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id)
        {
            var entity = await GetAsync(cancellationToken, id);

            entity.Status = status;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId)
        {
            return await AnyAsync(cancellationToken, toDoItem => toDoItem.Id == id && toDoItem.OwnerId == ownerId && (toDoItem.Status == Status.Active || toDoItem.Status == Status.Done));
        }
    }
}
