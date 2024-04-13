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

        [HttpPost]
        public async Task Update(UserRequestPutModel putModel)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            await _userService.UpdateAsync(putModel, id);
        }
    }
}
