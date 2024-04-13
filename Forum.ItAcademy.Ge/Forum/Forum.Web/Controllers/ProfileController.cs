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

        public async Task<IActionResult> Profile()
        {
            if (TempData["ErrorMessage"] is string errorMessage)
                ViewBag.ErrorMessage = errorMessage;

            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var user = await _userService.GetByIdAsync(id);

            return View();
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

        //public async Task<IActionResult> UpdateUsername([FromForm] UsernameRequestPutModel usernameModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(nameof(Profile));

        //    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var updateModel = new UserRequestPutModel
        //    {
        //        UserId = id,
        //        UpdatedUsername = usernameModel.Username
        //    };

        //    await _userService.UpdateUsernameAsync(updateModel);

        //    return RedirectToAction(nameof(Profile));
        //}

        //public async Task<IActionResult> UpdateEmail([FromForm] EmailRequestPutModel emailModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(nameof(Profile));

        //    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var updateModel = new UserRequestPutModel
        //    {
        //        UserId = id,
        //        Email = emailModel.Email
        //    };

        //    await _userService.UpdateEmailAsync(updateModel);

        //    return RedirectToAction(nameof(Profile));
        //}

        //public async Task<IActionResult> UpdatePassword([FromForm] PasswordRequestPutModel passwordModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(nameof(Profile));

        //    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var updateModel = new UserRequestPutModel
        //    {
        //        UserId = id,
        //        CurrentPassword = passwordModel.CurrentPassword,
        //        NewPassword = passwordModel.NewPassword
        //    };

        //    await _userService.UpdatePasswordAsync(updateModel);

        //    return RedirectToAction(nameof(Profile));
        //}
    }
}
