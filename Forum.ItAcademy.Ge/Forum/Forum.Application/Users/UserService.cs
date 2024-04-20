using Forum.Application.Exceptions;
using Forum.Application.Users.Interfaces;
using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Responses;
using Mapster;

namespace Forum.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UnbanUser(string id)
        {
            if (!await _userRepository.Exists(id))
                throw new UserNotFoundException();

            await _userRepository.UnbanUser(id);
        }

        public async Task BanUser(string id)
        {
            if (!await _userRepository.Exists(id))
                throw new UserNotFoundException();

            await _userRepository.BanUser(id);
        }

        public async Task<List<UserResponseAdminModel>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();

            return result.Adapt<List<UserResponseAdminModel>>();
        }

        public async Task<UserResponseModel> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsernameAsync(string username)
        {
            var result = await _userRepository.GetByUsernameAsync(username);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByEmailAsync(string email)
        {
            var result = await _userRepository.GetByEmailAsync(email);

            if (result == null)
                throw new UserNotFoundException();

            if (result.Image != null && result.Image.IsDeleted)
                result.Image = null;

            return result.Adapt<UserResponseModel>();
        }

        public async Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id)
        {
            if (!await _userRepository.Exists(id))
                throw new UserNotFoundException();

            await _userRepository.ChangePasswordAsync(passwordModel, id);
        }

        public async Task UpdateAsync(UserRequestPutModel updateModel, int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            if (updateModel.Email != null && await _userRepository.EmailExists(updateModel.Email))
                throw new EmailAlreadyExistsException();

            if (updateModel.UpdatedUsername != null && await _userRepository.UsernameExists(updateModel.UpdatedUsername))
                throw new UsernameAlreadyExistsException();

            if (updateModel.Email != null)
                user.Email = updateModel.Email;

            if (updateModel.UpdatedUsername != null)
                user.UserName = updateModel.UpdatedUsername;

            if (updateModel.Gender != null)
                user.Gender = updateModel.Gender;

            if (updateModel.Bio != null)
                user.Bio = updateModel.Bio;

            await _userRepository.UpdateAsync(user);

            await _userRepository.RefreshSignInAsync(user);
        }

        public async Task DeleteGenderAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException();

            user.Gender = null;

            await _userRepository.UpdateAsync(user);
        }
    }
}
