using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("update/username")]
        public async Task UpdateUsername(UsernameRequestPutModel usernameModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateModel = new UserRequestPutModel
            {
                UserId = id,
                UpdatedUsername = usernameModel.Username
            };

            await _userService.UpdateUsernameAsync(updateModel);
        }

        [HttpPost("update/email")]
        public async Task UpdateEmail(EmailRequestPutModel emailModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateModel = new UserRequestPutModel
            {
                UserId = id,
                Email = emailModel.Email
            };

            await _userService.UpdateEmailAsync(updateModel);
        }

        [HttpPost("update/password")]
        public async Task UpdatePassword(PasswordRequestPutModel passwordModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updateModel = new UserRequestPutModel
            {
                UserId = id,
                CurrentPassword = passwordModel.CurrentPassword,
                NewPassword = passwordModel.NewPassword
            };

            await _userService.UpdatePasswordAsync(updateModel);
        }
    }
}
