using Forum.Application.Exceptions;
using Forum.Application.Profiles.Interfaces;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserResponseModel> GetByIdAsync(int id)
        {
            var result = await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.Id == id);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsernameAsync(string username)
        {
            var result = await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.UserName == username);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByEmailAsync(string email)
        {
            var result = await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.Email == email);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            await _userManager.ChangePasswordAsync(user, passwordModel.CurrentPassword, passwordModel.NewPassword);
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

            if (updateModel.Email != null)
                user.Email = updateModel.Email;

            if (updateModel.UpdatedUsername != null)
                user.UserName = updateModel.UpdatedUsername;

            if (updateModel.Gender != null)
                user.Gender = updateModel.Gender;

            if (updateModel.Bio != null)
                user.Bio = updateModel.Bio;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task DeleteGenderAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            user.Gender = null;

            await _userManager.UpdateAsync(user);
        }

        public async Task<bool> UsernameExists(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
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
