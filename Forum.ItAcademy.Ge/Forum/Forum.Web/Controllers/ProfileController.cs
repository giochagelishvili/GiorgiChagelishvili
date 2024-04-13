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

        public IActionResult Profile()
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

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.ChangePasswordAsync(model, id);

            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UserRequestPutModel updateModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.UpdateAsync(updateModel, id);

            return RedirectToAction(nameof(Profile));
        }
    }
}
