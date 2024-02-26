using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAll(CancellationToken cancellationToken);
        Task<Pizza> Get(int id, CancellationToken cancellationToken);
        Task Create(Pizza pizza, CancellationToken cancellationToken);
        Task Update(Pizza pizza, CancellationToken cancellationToken);
        Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
    }
}
