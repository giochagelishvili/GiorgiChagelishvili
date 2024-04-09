using Forum.Application.Accounts.Updates;
using Forum.Domain.Users;

namespace Forum.Application.Profiles.Interfaces
{
    public interface IProfileService
    {
        Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<User> UpdateUsernameAsync(string currentUsername, UsernameRequestPutModel usernameModel, CancellationToken cancellationToken);
        Task<User> UpdateEmailAsync(string username, EmailRequestPutModel emailModel, CancellationToken cancellationToken);
        Task<User> UpdatePasswordAsync(PasswordRequestPutModel passwordModel, string username, CancellationToken cancellationToken);
        Task<bool> UsernameExists(string username, CancellationToken cancellationToken);
        Task<bool> EmailExists(string email, CancellationToken cancellationToken);
        Task SignInAsync(User user, bool isPersistent);
    }
}
