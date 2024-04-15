using Forum.Application.Topics.Interfaces;
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
            return await _dbSet.Include(x => x.Author)
                               .Include(x => x.Comments.Where(comment => !comment.IsDeleted))
                               .OrderByDescending(x => x.ModifiedAt)
                               .ToListAsync(cancellationToken);
        }

        public new async Task<Topic?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Id == id)
                               .Include(x => x.Author)
                               .Include(x => x.Comments.Where(comment => !comment.IsDeleted)).ThenInclude(x => x.Author)
                               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await AnyAsync(topic => topic.Id == id, cancellationToken);
        }
    }
}
