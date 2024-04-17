using Forum.Application.Images.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<FileContentResult> Get(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _imageService.GetAsync(userId, cancellationToken);

            return new FileContentResult(result, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile image, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _imageService.UploadAsync(image, userId, cancellationToken);

            return RedirectToAction("Profile", "Profile", new { id = userId });
        }

        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _imageService.DeleteAsync(userId, cancellationToken);

            return RedirectToAction("Profile", "Profile", new { id = userId });
        }
    }
}
