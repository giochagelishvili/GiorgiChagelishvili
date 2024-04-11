using Forum.Application.Topics.Interfaces;
using Forum.Domain.Topics;
using Forum.Persistence.Context;

namespace Forum.Infrastructure.Topics
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ForumContext context) : base(context)
        {
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
