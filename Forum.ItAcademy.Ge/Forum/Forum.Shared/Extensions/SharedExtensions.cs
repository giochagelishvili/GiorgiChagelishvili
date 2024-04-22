using Forum.Application.Accounts;
using Forum.Application.Accounts.Interfaces;
using Forum.Application.Comments;
using Forum.Application.Comments.Interfaces;
using Forum.Application.Images;
using Forum.Application.Images.Interfaces;
using Forum.Application.Users;
using Forum.Application.Users.Interfaces;
using Forum.Application.Topics;
using Forum.Application.Topics.Interfaces;
using Forum.Infrastructure.Comments;
using Forum.Infrastructure.Images;
using Forum.Infrastructure.Topics;
using Forum.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Forum.Domain.Roles;
using Microsoft.Extensions.Configuration;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Forum.Shared.Extensions
{
    public static class SharedExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IImageService, ImageService>();


            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddCustomValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

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

        public static async Task SeedRoles(this IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

            var roles = new[] { "Admin", "Member" };

            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new Role { Name = role });
        }

        public static void AddDbContextAndIdentity(this IServiceCollection services, IConfiguration configuration, ServiceLifetime contextLifeTime = ServiceLifetime.Scoped)
        {
            services.AddDbContext<ForumContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), contextLifetime: contextLifeTime);

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ForumContext>();
        }

        public static void UseConfiguredStaticFiles(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(configuration.GetValue<string>("Constants:UploadPath")),
                RequestPath = configuration.GetValue<string>("Constants:RequestPath")
            });
            builder.UseStaticFiles();
        }
    }
}