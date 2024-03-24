using ToDo.Domain.Users;

namespace ToDo.Application.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetAsync(CancellationToken cancellationToken, int id);
        Task<User?> GetByUsername(CancellationToken cancellationToken, string username);
        Task CreateAsync(CancellationToken cancellationToken, User user);
        Task UpdateAsync(CancellationToken cancellationToken, User user);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
    }
}
