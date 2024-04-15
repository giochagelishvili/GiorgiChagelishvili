using Forum.Application.Comments.Interfaces;
using Forum.Domain.Comments;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Comments
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ForumContext context) : base(context)
        {
        }

        public new async Task<Comment?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(comment => comment.Id == id && !comment.IsDeleted);
        }

        public async Task DeleteAsync(int commentId, CancellationToken cancellationToken)
        {
            var comment = await GetAsync(commentId, cancellationToken);

            comment.IsDeleted = true;

            _dbSet.Update(comment);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
