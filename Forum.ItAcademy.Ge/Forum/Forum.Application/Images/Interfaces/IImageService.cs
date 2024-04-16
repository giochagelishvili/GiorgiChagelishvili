using Forum.Application.Images.Requests;

namespace Forum.Application.Images.Interfaces
{
    public interface IImageService
    {
        Task CreateAsync(ImageRequestPostModel image, CancellationToken cancellationToken);
    }
}
