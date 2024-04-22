using Forum.Application.Exceptions;
using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Responses;
using Forum.Domain.Users;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Forum.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<List<string>> GetUserRolesAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var roles = await _userManager.GetRolesAsync(user);

            return roles.Adapt<List<string>>();
        }

        public async Task UnbanUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            user.IsBanned = false;
            user.BannedUntil = null;

            await _userManager.UpdateAsync(user);
        }

        public async Task BanUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var banDuration = _config.GetValue<int>("Constants:BanDuration");

            user.IsBanned = true;
            user.BannedUntil = DateTime.UtcNow.AddDays(banDuration);

            await _userManager.UpdateAsync(user);
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
            return await _userManager.FindByNameAsync(username) != null;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<bool> Exists(string id)
        {
            return await _userManager.FindByIdAsync(id) != null;
        }

        public async Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.ChangePasswordAsync(user, passwordModel.CurrentPassword, passwordModel.NewPassword);
        }


        // Repository calls
        public async Task<List<UserResponseAdminModel>> GetAllAdminAsync(int callerUserId, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllAdminAsync(callerUserId, cancellationToken);

            return result.Adapt<List<UserResponseAdminModel>>();
        }

        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAllAsync(cancellationToken);

            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task<UserResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(id, cancellationToken);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByUsernameAsync(username, cancellationToken);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByEmailAsync(email, cancellationToken);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<int> GetUserCommentCountAsync(int userId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserCommentCountAsync(userId, cancellationToken);
        }
    }
}
