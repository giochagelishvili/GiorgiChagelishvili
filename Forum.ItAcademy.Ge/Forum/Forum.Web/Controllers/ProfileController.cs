using Forum.Application.Exceptions;
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
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<IActionResult> Profile()
        {
            if (TempData["ErrorMessage"] is string errorMessage)
                ViewBag.ErrorMessage = errorMessage;

            var user = await _profileService.GetByUsernameAsync(User.Identity.Name);

            return View(user);
        }

        public async Task<IActionResult> UpdateUsername([FromForm] UsernameRequestPutModel usernameModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            if (await _profileService.UsernameExists(usernameModel.Username))
            {
                TempData["ErrorMessage"] = ErrorMessages.UsernameAlreadyExists;
                return RedirectToAction(nameof(Profile));
            }

            var updateModel = new UserRequestPutModel
            {
                CurrentUsername = User.Identity.Name,
                UpdatedUsername = usernameModel.Username
            };

            await _profileService.UpdateUsernameAsync(updateModel);

            await UpdateUsernameClaim(updateModel.UpdatedUsername);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> UpdateEmail([FromForm] EmailRequestPutModel emailModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            if (await _profileService.EmailExists(emailModel.Email))
            {
                TempData["ErrorMessage"] = ErrorMessages.EmailAlreadyExists;
                return RedirectToAction(nameof(Profile));
            }

            var updateModel = new UserRequestPutModel
            {
                CurrentUsername = User.Identity.Name,
                Email = emailModel.Email
            };

            await _profileService.UpdateEmailAsync(updateModel);

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

            await _profileService.UpdatePasswordAsync(updateModel);

            return RedirectToAction(nameof(Profile));
        }

        private async Task UpdateUsernameClaim(string username)
        {
            if (User.Identity == null)
                throw new UnauthorizedException();

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
            if (User.Identity == null)
                throw new UnauthorizedException();

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
