using Forum.API.Infrastructure.Authorization;
using Forum.Application.Accounts;
using Forum.Application.Exceptions;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        [Authorize]
        [HttpGet]
        public string Get()
        {
            return "Sagol brat!";
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                throw new UserNotFoundException();

            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (!signInResult.Succeeded)
                throw new InvalidPasswordException();

            return JWTHelper.GenerateToken(user, _config);
        }

        [HttpPost("register")]
        public async Task Register(RegisterRequestModel model)
        {
            var result = await _userManager.FindByEmailAsync(model.Email);

            if (result != null)
                throw new EmailAlreadyExistsException();

            result = await _userManager.FindByNameAsync(model.Username);

            if (result != null)
                throw new UsernameAlreadyExistsException();

            var user = new User { Email = model.Email, UserName = model.Username };

            var registerResult = await _userManager.CreateAsync(user, model.Password);

            if (!registerResult.Succeeded)
                throw new CouldNotRegisterException();
        }
    }
}