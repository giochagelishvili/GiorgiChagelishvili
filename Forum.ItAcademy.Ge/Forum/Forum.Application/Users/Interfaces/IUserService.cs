using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Responses;

namespace Forum.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<int> GetUserCommentCountAsync(int userId);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task UnbanUser(string id);
        Task BanUser(string id);
        Task<List<UserResponseAdminModel>> GetAllAsync(int callerUserId);
        Task<UserResponseModel> GetByIdAsync(int id);
        Task<UserResponseModel> GetByUsernameAsync(string username);
        Task<UserResponseModel> GetByEmailAsync(string email);
        Task UpdateAsync(UserRequestPutModel updateModel, int id);
        Task DeleteGenderAsync(int id);
        Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id);
    }
}
