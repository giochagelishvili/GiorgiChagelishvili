using Forum.Application.Topics.Requests;
using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicRepository
    {
        Task UpdateStatusAsync(TopicStatusPutModel status, CancellationToken cancellationToken);
        Task UpdateStateAsync(TopicStatePutModel model, CancellationToken cancellationToken);
        Task<List<TopicCommentsCount>> GetUserTopics(int userId, CancellationToken cancellationToken);
        Task<List<TopicCommentsCount>> GetAllAsync(CancellationToken cancellationToken);
        Task<Topic?> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Topic topic, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
