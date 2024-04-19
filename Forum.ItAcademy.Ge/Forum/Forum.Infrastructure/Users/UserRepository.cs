using Forum.Application.Users.Requests.Updates;
using Forum.Application.Users.Interfaces;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task UnbanUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            user.IsBanned = false;

            await _userManager.UpdateAsync(user);
        }

        public async Task BanUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            user.IsBanned = true;

            await _userManager.UpdateAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userManager.Users
                .Include(user => user.Image)
                .FirstOrDefaultAsync(user => user.UserName == username);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<bool> Exists(string id)
        {
            return await _userManager.FindByIdAsync(id) != null;
        }

        public async Task ChangePasswordAsync(PasswordRequestPutModel passwordModel, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            await _userManager.ChangePasswordAsync(user, passwordModel.CurrentPassword, passwordModel.NewPassword);
        }

        public async Task UpdateAsync(User updatedUser)
        {
            await _userManager.UpdateAsync(updatedUser);

            await _signInManager.RefreshSignInAsync(updatedUser);
        }
    }
}
