using Forum.Application.Accounts.Updates;
using Forum.Application.Exceptions;
using Forum.Application.Profiles.Interfaces;
using Forum.Domain.Users;
using Forum.Web.Infrastructure.Localizations;
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

        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
        {
            if (TempData["ErrorMessage"] is string errorMessage)
                ViewBag.ErrorMessage = errorMessage;

            var user = await _profileService.GetByUsernameAsync(User.Identity.Name, cancellationToken);

            return View(user);
        }

        public async Task<IActionResult> UpdateUsername([FromForm] UsernameRequestPutModel usernameModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            if (await _profileService.UsernameExists(usernameModel.Username, cancellationToken))
            {
                TempData["ErrorMessage"] = ErrorMessages.UsernameAlreadyExists;
                return RedirectToAction(nameof(Profile));
            }

            var updatedUser = await _profileService.UpdateUsernameAsync(User.Identity.Name, usernameModel, cancellationToken);

            await UpdateClaims(updatedUser);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> UpdateEmail([FromForm] EmailRequestPutModel emailModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            if (await _profileService.EmailExists(emailModel.Email, cancellationToken))
            {
                TempData["ErrorMessage"] = ErrorMessages.EmailAlreadyExists;
                return RedirectToAction(nameof(Profile));
            }

            var updatedUser = await _profileService.UpdateEmailAsync(User.Identity.Name, emailModel, cancellationToken);

            await UpdateClaims(updatedUser);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> UpdatePassword([FromForm] PasswordRequestPutModel passwordModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(nameof(Profile));

            var updatedUser = await _profileService.UpdatePasswordAsync(passwordModel, User.Identity.Name, cancellationToken);

            await UpdateClaims(updatedUser);

            return RedirectToAction(nameof(Profile));
        }

        private async Task UpdateClaims(User user)
        {
            if (User.Identity == null)
                throw new UnauthorizedException();

            var identity = (ClaimsIdentity)User.Identity;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            var emailClaim = identity.FindFirst(ClaimTypes.Email);

            if (usernameClaim != null)
            {
                identity.RemoveClaim(usernameClaim);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            }

            if (emailClaim != null)
            {
                identity.RemoveClaim(emailClaim);
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            }

            await _profileService.SignInAsync(user, true);
        }
    }
}
