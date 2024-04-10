using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Web.Infrastructure.Localizations;
using Microsoft.AspNetCore.Authentication;
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

        public async Task<IActionResult> Profile()
        {
            if (TempData["ErrorMessage"] is string errorMessage)
                ViewBag.ErrorMessage = errorMessage;

            var user = await _userService.GetByUsernameAsync(User.Identity.Name);

            return View(user);
        }

        public async Task<IActionResult> UpdateUsername([FromForm] UsernameRequestPutModel usernameModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var updateModel = new UserRequestPutModel
            {
                CurrentUsername = User.Identity.Name,
                UpdatedUsername = usernameModel.Username
            };

            await _userService.UpdateUsernameAsync(updateModel);

            await UpdateUsernameClaim(updateModel.UpdatedUsername);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> UpdateEmail([FromForm] EmailRequestPutModel emailModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var updateModel = new UserRequestPutModel
            {
                CurrentUsername = User.Identity.Name,
                Email = emailModel.Email
            };

            await _userService.UpdateEmailAsync(updateModel);

            await UpdateEmailClaim(updateModel.Email);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> UpdatePassword([FromForm] PasswordRequestPutModel passwordModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var updateModel = new UserRequestPutModel
            {
                CurrentUsername = User.Identity.Name,
                CurrentPassword = passwordModel.CurrentPassword,
                NewPassword = passwordModel.NewPassword
            };

            await _userService.UpdatePasswordAsync(updateModel);

            return RedirectToAction(nameof(Profile));
        }

        private async Task UpdateUsernameClaim(string username)
        {
            var identity = (ClaimsIdentity)User.Identity;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);

            if (usernameClaim != null)
            {
                identity.RemoveClaim(usernameClaim);
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
            }

            await HttpContext.SignInAsync(User.Identity.AuthenticationType, new ClaimsPrincipal(identity));
        }

        private async Task UpdateEmailClaim(string email)
        {
            var identity = (ClaimsIdentity)User.Identity;

            var emailClaim = identity.FindFirst(ClaimTypes.Email);

            if (emailClaim != null)
            {
                identity.RemoveClaim(emailClaim);
                identity.AddClaim(new Claim(ClaimTypes.Email, email));
            }

            await HttpContext.SignInAsync(User.Identity.AuthenticationType, new ClaimsPrincipal(identity));
        }
    }
}
