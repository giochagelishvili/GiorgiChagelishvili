using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;
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

        [HttpGet("user/{email}")]
        public async Task<UserResponseModel> GetByEmail(string email)
        {
            return await _userService.GetByEmailAsync(email);
        }

        [HttpGet("profile")]
        public async Task<UserResponseModel> Profile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return await _userService.GetByIdAsync(userId);
        }

        [HttpPost("update")]
        public async Task Update(UserRequestPutModel putModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.UpdateAsync(putModel, id);
        }

        [HttpPost("changepassword")]
        public async Task ChangePassword(PasswordRequestPutModel putModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.ChangePasswordAsync(putModel, id);
        }

        [HttpDelete("deletegender")]
        public async Task DeleteGender()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.DeleteGenderAsync(id);
        }
    }
}
