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

namespace Forum.Shared.Extensions
{
    public static class ServiceExtensions
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
    }
}
