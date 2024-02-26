namespace PizzaProject.Application.Addresses
{
    public interface IAddressService
    {
        Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<AddressResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(AddressRequestModel address, CancellationToken cancellationToken);
        Task Update(AddressRequestModel address, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
