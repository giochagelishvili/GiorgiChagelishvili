using Forum.Application.Exceptions;
using Forum.Application.Images.Interfaces;
using Forum.Domain.Images;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Forum.Application.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public ImageService(IImageRepository imageRepository, UserManager<User> userManager, IConfiguration config)
        {
            _imageRepository = imageRepository;
            _userManager = userManager;
            _config = config;
        }

        public async Task<byte[]> GetAsync(int userId, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetAsync(userId, cancellationToken);

            if (!File.Exists(image.Url))
                throw new FileNotFoundException();

            using var fileStream = new FileStream(image.Url, FileMode.Open);
            using var memoryStream = new MemoryStream();

            await fileStream.CopyToAsync(memoryStream, cancellationToken);

            return memoryStream.ToArray();
        }

        public async Task UploadAsync(IFormFile image, string userId, CancellationToken cancellationToken)
        {
            var url = await SaveImage(image, cancellationToken);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new UserNotFoundException();

            var entity = new Image
            {
                UserId = int.Parse(userId),
                Url = url
            };

            if (await _imageRepository.ExistsAsync(int.Parse(userId), cancellationToken))
                await _imageRepository.UpdateAsync(entity, cancellationToken);
            else
                await _imageRepository.CreateAsync(entity, cancellationToken);
        }

        private async Task<string> SaveImage(IFormFile image, CancellationToken cancellationToken)
        {
            var path = _config.GetValue<string>("Constants:UploadPath");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var ext = Path.GetExtension(image.FileName).ToLower();
            var validExtensions = new string[] { ".jpg", ".png", ".jpeg", ".webp", ".ico" };

            if (!validExtensions.Contains(ext))
                throw new InvalidExtensionException();

            var guid = Guid.NewGuid().ToString();
            var imageName = guid + ext;
            var imagePath = Path.Combine(path, imageName);

            using var stream = new FileStream(imagePath, FileMode.Create);

            await image.CopyToAsync(stream, cancellationToken);
            await stream.FlushAsync(cancellationToken);

            return imagePath;
        }

        public async Task DeleteAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UserNotFoundException();

            await _imageRepository.DeleteAsync(userId, cancellationToken);
        }
    }
}
