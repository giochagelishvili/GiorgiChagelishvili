using Forum.Application.Topics.Responses;
using Forum.Domain.Topics;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Shared.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings(this IServiceCollection _)
        {
            TypeAdapterConfig<Topic, TopicResponseModel>
                .NewConfig();
        }
    }
}
