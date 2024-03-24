using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.BaseEntities;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly ToDoContext _context;

        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ToDoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active || x.Status == Status.Done)
                               .ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbSet.Where(x => x.Id == id && (x.Status == Status.Active || x.Status == Status.Done))
                               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, T entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var entity = await GetAsync(cancellationToken, id);

            if (entity == null) return;

            entity.Status = Status.Deleted;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> AnyAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
