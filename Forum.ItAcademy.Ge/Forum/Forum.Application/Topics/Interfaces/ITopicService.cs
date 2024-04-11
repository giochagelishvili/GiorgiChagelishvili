using Forum.Application.Topics.Requests;
using Forum.Application.Topics.Responses;
using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<TopicResponseModel> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(TopicRequestPostModel topic, CancellationToken cancellationToken);
        Task UpdateAsync(Topic topic, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
