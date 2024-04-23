using Forum.Application.Topics.Requests;
using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicRepository
    {
        Task UpdateStatusAsync(TopicStatusPutModel status, CancellationToken cancellationToken);
        Task UpdateStateAsync(TopicStatePutModel model, CancellationToken cancellationToken);
        Task<List<TopicWithLatestComment>> GetTopicWithLatestComment(CancellationToken cancellationToken);
        Task<List<TopicCommentsCount>> GetUserTopics(int userId, CancellationToken cancellationToken);
        Task<List<TopicCommentsCount>> GetAllAdminAsync(CancellationToken cancellationToken);
        Task<List<TopicCommentsCount>> GetAllAsync(int itemsToSkip, int itemsToTake, CancellationToken cancellationToken);
        Task<int> GetTotalCountAsync(CancellationToken cancellationToken);
        Task<Topic?> GetAdminAsync(int id, CancellationToken cancellationToken);
        Task<Topic?> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Topic topic, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
        Task<bool> IsActiveAsync(int id, CancellationToken cancellationToken);
    }
}
