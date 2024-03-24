using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToDo.API.Infrastructure.Auth;
using ToDo.Application.Exceptions;
using ToDo.Application.Users.Interfaces;
using ToDo.Application.Users.Requests;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<AuthConfiguration> _authOptions;

        public UserController(IUserService userService, IOptions<AuthConfiguration> authOptions)
        {
            _userService = userService;
            _authOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public async Task<string> Login(CancellationToken cancellationToken, UserRequestPostModel user)
        {
            if (user == null)
                throw new InvalidEntityException();

            var result = await _userService.LoginAsync(cancellationToken, user);

            return JwtHelper.GenerateToken(result.Username, result.Id, _authOptions);
        }

        [Route("register")]
        [HttpPost]
        public async Task Register(CancellationToken cancellationToken, UserRequestPostModel user)
        {
            if (user == null)
                throw new InvalidEntityException();

            await _userService.RegisterAsync(cancellationToken, user).ConfigureAwait(false);
        }
    }
}
