using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Forum.Domain.Roles;
using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Forum.Application.Users.Interfaces;
using Forum.Infrastructure.Users;
using Forum.Application.Users;
using Forum.Application.Comments.Interfaces;
using Forum.Infrastructure.Comments;
using Forum.Application.Comments;
using Forum.Infrastructure.Topics;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics;
using Forum.Workers.Bans;
using Forum.Workers.Archives;

namespace Forum.Workers
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            try
            {
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ForumContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), contextLifetime: ServiceLifetime.Transient);
                    services.AddIdentity<User, Role>().AddEntityFrameworkStores<ForumContext>();
                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<IUserService, UserService>();
                    services.AddSingleton<BanService>();
                    services.AddHostedService<BanWorker>();
                    services.AddTransient<ICommentRepository, CommentRepository>();
                    services.AddTransient<ICommentService, CommentService>();
                    services.AddTransient<ITopicRepository, TopicRepository>();
                    services.AddTransient<ITopicService, TopicService>();
                    services.AddTransient<ArchiveService>();
                    services.AddHostedService<ArchiveWorker>();
                });
        }
    }
}
