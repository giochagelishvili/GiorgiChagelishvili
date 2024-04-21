﻿using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicService
    {
        Task UpdateStatusAsync(TopicStatusPutModel status, CancellationToken cancellationToken);
        Task UpdateStateAsync(TopicStatePutModel state, CancellationToken cancellationToken);
        Task<TopicResponseAdminModel> GetAdminTopic(int id, CancellationToken cancellationToken);
        Task<List<TopicResponseAdminFeedModel>> GetAdminTopics(CancellationToken cancellationToken);
        Task<List<TopicResponseNewsFeedModel>> GetUserTopics(int userId, CancellationToken cancellationToken);
        Task<List<TopicResponseNewsFeedModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<TopicResponseModel> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(TopicRequestPostModel topic, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        Task<bool> IsActiveAsync(int id, CancellationToken cancellationToken);
    }
}
