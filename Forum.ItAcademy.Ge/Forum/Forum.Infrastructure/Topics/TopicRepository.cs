using Forum.Application.Topics.Interfaces;
using Forum.Domain;
using Forum.Domain.Topics;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Topics
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ForumContext context) : base(context)
        {
        }

        public new async Task<List<Topic>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active)
                               .Include(x => x.Author)
                               .Include(x => x.Comments)
                               .ToListAsync(cancellationToken);
        }

        public new async Task<Topic?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active && x.Id == id)
                               .Include(x => x.Author)
                               .Include(x => x.Comments)
                               .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
