using Microsoft.EntityFrameworkCore;
using ToDo.Application.Users.Interfaces;
using ToDo.Domain.BaseEntities;
using ToDo.Domain.Users;
using ToDo.Persistence.Context;

namespace ToDo.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsername(CancellationToken cancellationToken, string username)
        {
            return await _dbSet.SingleOrDefaultAsync(user => user.Username == username, cancellationToken)
                               .ConfigureAwait(false);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await AnyAsync(cancellationToken, user => user.Id == id && user.Status != Status.Deleted)
                                 .ConfigureAwait(false);
        }
    }
}
