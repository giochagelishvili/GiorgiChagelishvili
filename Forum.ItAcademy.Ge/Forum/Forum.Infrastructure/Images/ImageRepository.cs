using Forum.Application.Images.Interfaces;
using Forum.Domain.Images;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Images
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ForumContext context) : base(context)
        {
        }

        public new async Task<Image?> GetAsync(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(image => image.UserId == userId && !image.IsDeleted, cancellationToken);
        }

        public async Task<bool> ExistsAsync(int userId, CancellationToken cancellationToken)
        {
            return await AnyAsync(image => image.UserId == userId, cancellationToken);
        }

        public new async Task UpdateAsync(Image updatedImage, CancellationToken cancellationToken)
        {
            var image = await _dbSet
                .FirstOrDefaultAsync(image => image.UserId == updatedImage.UserId, cancellationToken);

            image.Url = updatedImage.Url;

            if (image.IsDeleted)
                image.IsDeleted = false;

            _dbSet.Update(image);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int userId, CancellationToken cancellationToken)
        {
            var image = await _dbSet
                .FirstOrDefaultAsync(image => image.UserId == userId, cancellationToken);

            image.IsDeleted = true;

            _dbSet.Update(image);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
