using Forum.Domain.Topics;

namespace Forum.Application.Topics.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllAsync(CancellationToken cancellationToken);
        Task<Topic?> GetAsync(int id, CancellationToken cancellationToken);
        Task CreateAsync(Topic topic, CancellationToken cancellationToken);
        Task UpdateAsync(Topic topic, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
