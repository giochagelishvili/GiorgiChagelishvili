using Forum.Domain;
using Forum.Domain.BaseEntities;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Forum.Infrastructure
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly ForumContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ForumContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active)
                               .ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active && x.Id == id)
                               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await GetAsync(id, cancellationToken);

            if (entity == null) return;

            entity.Status = Status.Inactive;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
