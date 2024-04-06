using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll(CancellationToken cancellationToken);
        Task<Address> Get(int id, CancellationToken cancellationToken);
        Task Create(Address address, CancellationToken cancellationToken);
        Task Update(Address address, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<bool> Exists(int id, CancellationToken cancellationToken);
        Task<bool> AddressExistsForUser(int userId, int? addressId, CancellationToken cancellationToken);
    }
}
