using Forum.Application.Images.Interfaces;
using Forum.Application.Images.Requests;
using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public ProfileController(IUserService userService, IImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> Profile(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return View(user);
        }

        [HttpGet("editprofile")]
        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile image, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                    image.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);

                await image.CopyToAsync(stream);

                var postModel = new ImageRequestPostModel
                {
                    Url = "/uploads/" + image.FileName,
                    UserId = userId
                };

                await _imageService.CreateAsync(postModel, cancellationToken);
            }

            return RedirectToAction(nameof(Profile), new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] PasswordRequestPutModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.ChangePasswordAsync(model, userId);

            return RedirectToAction(nameof(Profile), new { id = userId });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UserRequestPutModel updateModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.UpdateAsync(updateModel, userId);

            return RedirectToAction(nameof(Profile), new { id = userId });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGender()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.DeleteGenderAsync(userId);

            return RedirectToAction(nameof(Profile), new { id = userId });
        }
    }
}
