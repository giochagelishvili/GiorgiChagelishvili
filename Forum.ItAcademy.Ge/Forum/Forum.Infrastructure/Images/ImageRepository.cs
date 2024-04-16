using Forum.Application.Images.Interfaces;
using Forum.Domain.Images;
using Forum.Persistence.Context;

namespace Forum.Infrastructure.Images
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ForumContext context) : base(context)
        {
        }
    }
}
