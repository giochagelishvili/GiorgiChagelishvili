using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.Requests;
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

        public async Task UpdateStatusAsync(TopicStatusPutModel model, CancellationToken cancellationToken)
        {
            var topic = await _dbSet.FirstOrDefaultAsync(topic => topic.Id == model.Id, cancellationToken);

            topic.Status = model.Status;

            _dbSet.Update(topic);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStateAsync(TopicStatePutModel model, CancellationToken cancellationToken)
        {
            var topic = await _dbSet.FirstOrDefaultAsync(topic => topic.Id == model.Id, cancellationToken);

            topic.State = model.State;

            _dbSet.Update(topic);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TopicCommentsCount>> GetUserTopics(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(topic => topic.Author)
                .Where(topic => topic.AuthorId == userId && topic.State == State.Show)
                .Select(topic => new TopicCommentsCount
                {
                    Topic = topic,
                    CommentCount = topic.Comments.Where(comment => !comment.IsDeleted).Count()
                }).ToListAsync(cancellationToken);
        }

        public new async Task<List<TopicCommentsCount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(topic => topic.Author)
                .Where(topic => topic.State == State.Show)
                .OrderByDescending(topic => topic.CreatedAt)
                .Select(topic => new TopicCommentsCount
                {
                    Topic = topic,
                    CommentCount = topic.Comments.Where(comment => !comment.IsDeleted).Count()
                })
                .ToListAsync(cancellationToken);
        }

        public new async Task<Topic?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Id == id && x.State == State.Show)
                               .Include(x => x.Author)
                               .Include(x => x.Comments.Where(comment => !comment.IsDeleted)).ThenInclude(x => x.Author)
                               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TopicCommentsCount>> GetAllAdminAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Include(topic => topic.Author)
                               .OrderByDescending(topic => topic.CreatedAt)
                               .Select(topic => new TopicCommentsCount
                               {
                                   Topic = topic,
                                   CommentCount = topic.Comments.Where(comment => !comment.IsDeleted).Count()
                               }).ToListAsync(cancellationToken);
        }

        public async Task<Topic?> GetAdminAsync(int id, CancellationToken cancellationToken)
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
