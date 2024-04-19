using Forum.API.Infrastructure.Extensions;
using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Forum.API.Infrastructure.Middlewares.ExceptionHandling;
using Forum.API.Infrastructure.Middlewares.Culture;
using Forum.Domain.Roles;
using Forum.Shared.Extensions;
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.FileProviders;

namespace Forum.API
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

            builder.Services.AddTokenAuthorizaion(builder.Configuration);

            builder.Services.AddCustomValidators();

            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddServices();

            builder.Services.AddControllers();

            builder.Services.UseSwaggerConfiguration();

            var app = builder.Build();

            app.UseMiddleware<CultureMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            await app.Services.SeedRoles();
            await app.Services.SeedAdmin();

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(builder.Configuration.GetValue<string>("Constants:UploadPath")),
                RequestPath = "/" + builder.Configuration.GetValue<string>("Constants:RequestPath")
            });

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}