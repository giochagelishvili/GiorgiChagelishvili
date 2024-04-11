using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Forum.Web.Infrastructure.Middlewares;
using Serilog;
using Forum.Domain.Roles;
using Forum.Shared.Extensions;

namespace Forum.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddDbContext<ForumContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<ForumContext>();

            builder.Services.AddCustomValidators();

            builder.Services.AddSession();

            builder.Services.AddServices();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseSession();

            app.UseExceptionHandlerMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.Services.SeedRoles();
            await app.Services.SeedAdmin();

            app.Run();
        }
    }
}