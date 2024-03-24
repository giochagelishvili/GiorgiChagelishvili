using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo.API.Infrastructure.Auth;
using ToDo.API.Infrastructure.Extensions;
using ToDo.API.Infrastructure.Mappings;
using ToDo.Persistence;
using ToDo.Persistence.Context;
using Serilog;
using Microsoft.OpenApi.Models;

namespace ToDo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.UseSwaggerConfiguration();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "To-Do API",
                    Description = "API for To-Do list management.",
                    Contact = new OpenApiContact
                    {
                        Name = "Chagela's LinkedIn",
                        Url = new Uri("https://www.linkedin.com/in/giochagelishvili/"),
                    },
                });
            });

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(builder.Configuration)
                                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddServices();

            builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddDbContext<ToDoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            builder.Services.Configure<AuthConfiguration>(builder.Configuration.GetSection(nameof(AuthConfiguration)));
            builder.Services.AddTokenAuth(builder.Configuration);

            builder.Services.RegisterMappings();

            var app = builder.Build();

            app.UseCultureMiddleware();

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