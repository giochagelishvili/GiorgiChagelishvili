using Forum.Application.Profiles.Requests.Updates;
using Forum.Application.Profiles.Responses;

namespace Forum.Application.Profiles.Interfaces
{
    public interface IProfileService
    {
        Task<UserResponseModel> GetByUsernameAsync(string username);
        Task UpdateUsernameAsync(UserRequestPutModel user);
        Task UpdateEmailAsync(UserRequestPutModel user);
        Task UpdatePasswordAsync(UserRequestPutModel user);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
    }
}
