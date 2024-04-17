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

        public ProfileController(IUserService userService)
        {
            _userService = userService;
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
