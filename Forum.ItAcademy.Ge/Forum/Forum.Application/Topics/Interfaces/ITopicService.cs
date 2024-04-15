using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicResponseNewsFeedModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<TopicResponseModel> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(TopicRequestPostModel topic, CancellationToken cancellationToken);
    }
}
