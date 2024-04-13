using Forum.Application.Accounts.Interfaces;
using Forum.Application.Accounts.Requests;
using Forum.Application.Exceptions;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task SignInAsync(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                throw new UserNotFoundException();

            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, false);

            if (!signInResult.Succeeded)
                throw new InvalidPasswordException();
        }

        public async Task RegisterAsync(RegisterRequestModel model)
        {
            var result = await _userManager.FindByEmailAsync(model.Email);

            if (result != null)
                throw new EmailAlreadyExistsException();

            result = await _userManager.FindByNameAsync(model.Username);

            if (result != null)
                throw new UsernameAlreadyExistsException();

            var user = new User { Email = model.Email, UserName = model.Username, Gender = model.Gender };

            var registerResult = await _userManager.CreateAsync(user, model.Password);

            if (!registerResult.Succeeded)
                throw new CouldNotRegisterException();
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
