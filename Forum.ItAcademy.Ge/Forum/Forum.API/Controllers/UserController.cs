using Forum.Application.Users.Interfaces.Services;
using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Forum.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("unban/{id}")]
        public async Task UnbanUser(string id)
        {
            await _userService.UnbanUser(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("ban/{id}")]
        public async Task BanUser(string id)
        {
            await _userService.BanUser(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/users")]
        public async Task<List<UserResponseAdminModel>> GetAllUsersAdmin(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return await _userService.GetAllAdminAsync(userId, cancellationToken);
        }

        [AllowAnonymous]
        [HttpGet("user/{email}")]
        public async Task<UserResponseModel> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _userService.GetByEmailAsync(email, cancellationToken);
        }

        [AllowAnonymous]
        [HttpGet("profile")]
        public async Task<UserResponseModel> Profile(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return await _userService.GetByIdAsync(userId, cancellationToken);
        }

        [HttpPost("update")]
        public async Task Update(UserRequestPutModel putModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _userService.DeleteGenderAsync(id);
        }
    }
}
