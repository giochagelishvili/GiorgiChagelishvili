using Forum.Domain.Images;

namespace Forum.Application.Images.Interfaces
{
    public interface IImageRepository
    {
        Task CreateAsync(Image image, CancellationToken cancellationToken);
    }
}
