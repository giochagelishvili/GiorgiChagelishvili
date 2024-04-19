using Forum.Application.Users.Requests.Updates;
using Forum.Domain.Users;

namespace Forum.Application.Users.Interfaces
{
    public interface IUserRepository
    {
        Task UnbanUser(string id);
        Task BanUser(string id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task UpdateAsync(User updatedUser);
        Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
        Task<bool> Exists(string id);
    }
}
