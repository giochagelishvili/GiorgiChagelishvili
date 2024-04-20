using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Forum.Web.Infrastructure.Middlewares;
using Serilog;
using Forum.Domain.Roles;
using Forum.Shared.Extensions;
using Microsoft.Extensions.FileProviders;

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(builder.Configuration.GetValue<string>("Constants:UploadPath")),
                RequestPath = builder.Configuration.GetValue<string>("Constants:RequestPath")
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Topic}/{action=Topics}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Topic}/{action=Topics}/{id?}");
            });

            await app.Services.SeedRoles();
            await app.Services.SeedAdmin();

            app.Run();
        }
    }
}