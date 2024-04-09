using Forum.Application.Accounts.Updates;
using Forum.Application.Exceptions;
using Forum.Application.Profiles.Interfaces;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ProfileService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> UsernameExists(string username, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return false;

            return true;
        }

        public async Task<bool> EmailExists(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return false;

            return true;
        }

        public async Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }

        public async Task<User> UpdateEmailAsync(string username, EmailRequestPutModel emailModel, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                throw new UserNotFoundException();

            user.Email = emailModel.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            return user;
        }

        public async Task<User> UpdatePasswordAsync(PasswordRequestPutModel passwordModel, string username, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                throw new UserNotFoundException();

            var result = await _userManager.ChangePasswordAsync(user, passwordModel.OldPassword, passwordModel.Password);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            return user;
        }

        public async Task<User> UpdateUsernameAsync(string currentUsername, UsernameRequestPutModel usernameModel, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(currentUsername);

            if (user == null)
                throw new UserNotFoundException();

            user.UserName = usernameModel.Username;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ErrorWhileProcessingException();

            return user;
        }
    }
}
