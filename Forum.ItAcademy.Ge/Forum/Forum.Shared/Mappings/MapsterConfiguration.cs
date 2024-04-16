﻿using Forum.Application.Profiles.Responses;
using Forum.Application.Topics.Responses;
using Forum.Domain.Topics;
using Forum.Domain.Users;
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

            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig()
                .Map(dest => dest.ImageUrl, src => src.Image.Url);

            TypeAdapterConfig<TopicCommentsCount, TopicResponseNewsFeedModel>
                .NewConfig();
        }
    }
}
