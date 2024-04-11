using Forum.Application.Accounts;
using Forum.Application.Accounts.Interfaces;
using Forum.Application.Profiles;
using Forum.Application.Profiles.Interfaces;
using Forum.Application.Topics;
using Forum.Application.Topics.Interfaces;
using Forum.Infrastructure.Topics;
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


            services.AddScoped<ITopicRepository, TopicRepository>();
        }
    }
}
