using FluentValidation.AspNetCore;
using FluentValidation;
using Forum.API.Infrastructure.Extensions;
using Forum.Domain.Users;
using Forum.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;
using Forum.API.Infrastructure.Middlewares.ExceptionHandling;
using Forum.API.Infrastructure.Middlewares.Culture;
using Forum.Domain.Roles;
using Forum.Web.Infrastructure.Extensions;

namespace Forum.API
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

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

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}