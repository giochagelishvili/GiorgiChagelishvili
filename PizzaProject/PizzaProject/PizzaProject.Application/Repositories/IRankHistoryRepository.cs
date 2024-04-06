using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IRankHistoryRepository
    {
        Task<List<RankHistory>> GetAll(CancellationToken cancellationToken);
        Task<RankHistory> Get(int id, CancellationToken cancellationToken);
        Task Create(RankHistory rankHistory, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
