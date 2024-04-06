using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll(CancellationToken cancellationToken);
        Task<Order> Get(int id, CancellationToken cancellationToken);
        Task Create(Order order, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
        Task<bool> UserOrderedPizza(int userId, int pizzaId, CancellationToken cancellationToken);
    }
}
