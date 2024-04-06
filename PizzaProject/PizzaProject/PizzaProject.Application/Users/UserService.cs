using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null || result.Count <= 0)
                throw new UserNotFoundException();

            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task<UserResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new UserNotFoundException();

            var result = await _repository.Get(id, cancellationToken);

            return result.Adapt<UserResponseModel>();
        }

        public async Task Create(UserRequestModel user, CancellationToken cancellationToken)
        {
            var userToInsert = user.Adapt<User>();

            await _repository.Create(userToInsert, cancellationToken);
        }

        public async Task Update(UserRequestModel user, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(user.Id, cancellationToken))
                throw new UserNotFoundException();

            var userToUpdate = user.Adapt<User>();

            await _repository.Update(userToUpdate, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new UserNotFoundException();

            await _repository.Delete(id, cancellationToken);
        }
    }
}
