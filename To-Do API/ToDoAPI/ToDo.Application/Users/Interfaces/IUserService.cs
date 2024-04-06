using ToDo.Application.Users.Requests;
using ToDo.Application.Users.Responses;

namespace ToDo.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseModel> LoginAsync(CancellationToken cancellationToken, UserRequestPostModel user);
        Task RegisterAsync(CancellationToken cancellationToken, UserRequestPostModel user);
        Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<UserResponseModel> GetByUsername(CancellationToken cancellationToken, string username);
    }
}
