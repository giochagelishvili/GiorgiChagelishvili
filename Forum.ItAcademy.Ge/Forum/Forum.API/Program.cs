using Forum.API.Infrastructure.Extensions;
using Serilog;
using Forum.API.Infrastructure.Middlewares.ExceptionHandling;
using Forum.API.Infrastructure.Middlewares.Culture;
using Forum.Shared.Extensions;

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

            builder.Services.AddDbContextAndIdentity(builder.Configuration);

            builder.Services.AddTokenAuthorizaion(builder.Configuration);

            builder.Services.AddCustomValidators();

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

            app.UseConfiguredStaticFiles(builder.Configuration);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}