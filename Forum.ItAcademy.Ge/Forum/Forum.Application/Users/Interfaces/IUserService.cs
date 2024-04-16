using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;

namespace Forum.Application.Profiles.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseModel> GetByIdAsync(string id);
        Task<UserResponseModel> GetByUsernameAsync(string username);
        Task UpdateAsync(UserRequestPutModel updateModel, string id);
        Task DeleteGenderAsync(string id);
        Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
    }
}
