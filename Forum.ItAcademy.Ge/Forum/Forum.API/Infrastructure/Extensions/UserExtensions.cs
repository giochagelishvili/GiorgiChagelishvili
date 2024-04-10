using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class UserExtensions
    {
        public static async Task SeedAdmin(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            string email = "admin@admin.com";
            string username = "admin";
            string password = "Chagela123!";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var admin = new User { UserName = username, Email = email };

                await userManager.CreateAsync(admin, password);

                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
