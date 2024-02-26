using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _addressRepository.GetAll(cancellationToken);

            if (result == null || result.Count <= 0)
                throw new AddressNotFoundException();

            return result.Adapt<List<AddressResponseModel>>();
        }

        public async Task<AddressResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _addressRepository.Get(id, cancellationToken);

            if (result == null)
                throw new AddressNotFoundException();

            return result.Adapt<AddressResponseModel>();
        }

        public async Task Create(AddressRequestModel address, CancellationToken cancellationToken)
        {
            var addressToInsert = address.Adapt<Address>();

            await _addressRepository.Create(addressToInsert, cancellationToken);
        }

        public async Task Update(AddressRequestModel address, CancellationToken cancellationToken)
        {
            if (!await _addressRepository.Exists(address.Id, cancellationToken))
                throw new AddressNotFoundException();

            var addressToUpdate = address.Adapt<Address>();

            await _addressRepository.Update(addressToUpdate, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await _addressRepository.Exists(id, cancellationToken))
                throw new AddressNotFoundException();

            await _addressRepository.Delete(id, cancellationToken);
        }
    }
}
