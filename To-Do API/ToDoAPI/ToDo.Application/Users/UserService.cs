
using BC = BCrypt.Net.BCrypt;
using Mapster;
using ToDo.Application.Exceptions;
using ToDo.Application.Users.Interfaces;
using ToDo.Application.Users.Requests;
using ToDo.Application.Users.Responses;
using ToDo.Domain.Users;

namespace ToDo.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> LoginAsync(CancellationToken cancellationToken, UserRequestPostModel user)
        {
            var result = await _repository.GetByUsername(cancellationToken, user.Username);

            if (result == null)
                throw new UserNotFoundException();

            var verifyPassword = BC.EnhancedVerify(user.Password, result.PasswordHash);

            if (!verifyPassword)
                throw new InvalidPasswordException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task RegisterAsync(CancellationToken cancellationToken, UserRequestPostModel user)
        {
            user.Password = BC.EnhancedHashPassword(user.Password, 13);

            var userEntity = user.Adapt<User>();

            await _repository.CreateAsync(cancellationToken, userEntity);
        }

        public async Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null)
                throw new UserNotFoundException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> GetByUsername(CancellationToken cancellationToken, string username)
        {
            var result = await _repository.GetByUsername(cancellationToken, username);

            if (result == null)
                throw new UserNotFoundException();

            return result.Adapt<UserResponseModel>();
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await _repository.Exists(cancellationToken, id);
        }
    }
}
