using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Responses;

namespace Forum.Application.Users.Interfaces
{
    public interface IUserService
    {
        // Get
        Task<List<UserResponseAdminModel>> GetAllAdminAsync(int callerUserId, CancellationToken cancellationToken);
        Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserResponseModel> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<UserResponseModel> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<UserResponseModel> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<int> GetUserCommentCountAsync(int userId, CancellationToken cancellationToken);
        Task<List<string>> GetUserRolesAsync(string userId);

        // Update
        Task UnbanUser(string id);
        Task BanUser(string id);
        Task UpdateAsync(UserRequestPutModel updateModel, string id);
        Task DeleteGenderAsync(string id);
        Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id);
    }
}
