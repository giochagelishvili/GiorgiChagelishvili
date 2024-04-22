﻿using Forum.Domain.Users;

namespace Forum.Application.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<int> GetUserCommentCountAsync(int userId, CancellationToken cancellationToken);
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<User>> GetAllAdminAsync(int callerUserId, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
