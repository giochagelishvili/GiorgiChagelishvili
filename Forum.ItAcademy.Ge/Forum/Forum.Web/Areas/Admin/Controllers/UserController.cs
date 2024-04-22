using Forum.Application.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Users(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var users = await _userService.GetAllAdminAsync(userId, cancellationToken);

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> BanUser(string userId)
        {
            await _userService.BanUser(userId);

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        public async Task<IActionResult> UnbanUser(string userId)
        {
            await _userService.UnbanUser(userId);

            return RedirectToAction(nameof(Users));
        }
    }
}
