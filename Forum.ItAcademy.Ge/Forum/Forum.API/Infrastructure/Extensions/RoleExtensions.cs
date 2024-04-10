using Forum.Domain.Roles;
using Microsoft.AspNetCore.Identity;

namespace Forum.Web.Infrastructure.Extensions
{
    public static class RoleExtensions
    {
        public static async Task SeedRoles(this IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            var roles = new[] { "Admin", "Member" };

            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new Role { Name = role });
        }
    }
}
