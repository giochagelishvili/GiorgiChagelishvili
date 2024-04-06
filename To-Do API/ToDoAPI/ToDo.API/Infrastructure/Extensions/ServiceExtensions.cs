using ToDo.Application.Subtasks;
using ToDo.Application.Subtasks.Interfaces;
using ToDo.Application.ToDos;
using ToDo.Application.ToDos.Interfaces;
using ToDo.Application.Users;
using ToDo.Application.Users.Interfaces;
using ToDo.Infrastructure.Subtasks;
using ToDo.Infrastructure.ToDos;
using ToDo.Infrastructure.Users;

namespace ToDo.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToDoItemService, ToDoItemService>();
            services.AddScoped<ISubtaskService, SubtaskService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<ISubtaskRepository, SubtaskRepository>();
        }
    }
}
