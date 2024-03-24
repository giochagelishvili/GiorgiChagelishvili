using Microsoft.EntityFrameworkCore;
using ToDo.Application.Subtasks.Interfaces;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Subtasks;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.Subtasks
{
    public class SubtaskRepository : BaseRepository<Subtask>, ISubtaskRepository
    {
        public SubtaskRepository(ToDoContext toDoContext) : base(toDoContext)
        {
        }

        public async Task<List<Subtask>> GetAllAsync(CancellationToken cancellationToken, int toDoItemId)
        {
            return await _context.Set<Subtask>()
                                 .Where(subtask => subtask.ToDoItemId == toDoItemId)
                                 .ToListAsync(cancellationToken);
        }

        public new async Task UpdateAsync(CancellationToken cancellationToken, Subtask subtask)
        {
            var result = await GetAsync(cancellationToken, subtask.Id);

            result.Title = subtask.Title;

            _dbSet.Update(result);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, Status status, int id)
        {
            var result = await GetAsync(cancellationToken, id);

            result.Status = status;

            _dbSet.Update(result);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id, int ownerId)
        {
            var result = await _context.Set<Subtask>()
                                       .Include(subtask => subtask.ToDoItem)
                                       .FirstOrDefaultAsync(subtask => subtask.Id == id && (subtask.Status == Status.Active || subtask.Status == Status.Done));

            if (result == null)
                return false;

            return result.ToDoItem.OwnerId == ownerId;
        }
    }
}
