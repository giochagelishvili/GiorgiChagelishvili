using Microsoft.AspNetCore.Http;

namespace Forum.Application.Images.Interfaces
{
    public interface IImageService
    {
        Task<string> GetAsync(int userId, CancellationToken cancellationToken);
        Task UploadAsync(IFormFile image, string userId, CancellationToken cancellationToken);
        Task DeleteAsync(int userId, CancellationToken cancellationToken);
    }
}
