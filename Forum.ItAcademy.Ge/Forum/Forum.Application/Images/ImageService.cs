using Forum.Application.Exceptions;
using Forum.Application.Images.Interfaces;
using Forum.Application.Images.Requests;
using Forum.Domain.Images;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly UserManager<User> _userManager;

        public ImageService(IImageRepository imageRepository, UserManager<User> userManager)
        {
            _imageRepository = imageRepository;
            _userManager = userManager;
        }

        public async Task CreateAsync(ImageRequestPostModel image, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(image.UserId);

            if (user == null)
                throw new UserNotFoundException();

            var entity = image.Adapt<Image>();

            await _imageRepository.CreateAsync(entity, cancellationToken);
        }
    }
}
