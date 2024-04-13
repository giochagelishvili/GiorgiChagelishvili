using Forum.Application.Exceptions;
using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;
using Forum.Domain;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Forum.Application.Profiles
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task UpdateAsync(UserRequestPutModel updateModel, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            if (updateModel.Email != null && await EmailExists(updateModel.Email))
                throw new EmailAlreadyExistsException();

            if (updateModel.UpdatedUsername != null && await UsernameExists(updateModel.UpdatedUsername))
                throw new UsernameAlreadyExistsException();

            if (updateModel.CurrentPassword != null && updateModel.NewPassword != null)
                await _userManager.ChangePasswordAsync(user, updateModel.CurrentPassword, updateModel.NewPassword);

            if (updateModel.Email != null)
                user.Email = updateModel.Email;

            if (updateModel.UpdatedUsername != null)
                user.UserName = updateModel.UpdatedUsername;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task<UserResponseModel> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            return user.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsernameAsync(string username)
        {
            var result = await _userManager.FindByNameAsync(username);

            if (result == null || result.Status == Status.Inactive)
                throw new UserNotFoundException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task<bool> UsernameExists(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.Status == Status.Inactive)
                return false;

            return true;
        }

        public async Task<bool> EmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return false;

            return true;
        }
    }
}
