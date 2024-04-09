using Forum.Application.Exceptions;
using Forum.Domain.Users;
using Forum.Web.Infrastructure.Localizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Profile()
        {
            if (User.Identity == null)
                throw new UnauthorizedException();

            var errorMessage = TempData["ErrorMessage"] as string;

            if (errorMessage != null)
                ViewBag.ErrorMessage = errorMessage;

            var username = User.Identity.Name;

            User user = await _userManager.FindByNameAsync(username);

            return View(user);
        }

        public async Task<IActionResult> EditUsername(string username)
        {
            if (User.Identity == null)
                throw new UnauthorizedException();

            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                TempData["ErrorMessage"] = ErrorMessages.UsernameAlreadyExists;
                return RedirectToAction(nameof(Profile));
            }

            user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.UserName = username;

            await _userManager.UpdateAsync(user);

            await UpdateClaims(user);

            return RedirectToAction(nameof(Profile));
        }

        private async Task UpdateClaims(User user)
        {
            if (User.Identity == null)
                throw new UnauthorizedException();

            var identity = (ClaimsIdentity)User.Identity;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);

            if (usernameClaim != null)
            {
                identity.RemoveClaim(usernameClaim);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            }

            await _signInManager.SignInAsync(user, true);
        }
    }
}
