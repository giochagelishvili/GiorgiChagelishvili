using Mapster;
using ToDo.Application.Subtasks.Requests;
using ToDo.Application.Subtasks.Responses;
using ToDo.Application.ToDos.Requests;
using ToDo.Application.ToDos.Responses;
using ToDo.Application.Users.Requests;
using ToDo.Application.Users.Responses;
using ToDo.Domain.Subtasks;
using ToDo.Domain.ToDos;
using ToDo.Domain.Users;

namespace ToDo.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig();

            TypeAdapterConfig<UserRequestPostModel, User>
                .NewConfig()
                .Map(dest => dest.PasswordHash, src => src.Password);

            TypeAdapterConfig<ToDoItem, ToDoItemResponseModel>
                .NewConfig();

            TypeAdapterConfig<ToDoItemRequestPostModel, ToDoItem>
                .NewConfig();

            TypeAdapterConfig<Subtask, SubtaskResponseModel>
                .NewConfig();

            TypeAdapterConfig<Subtask, SubtaskRequestPostModel>
                .NewConfig();
        }
    }
}
