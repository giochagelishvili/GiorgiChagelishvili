using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Addresses;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Get all addresses from the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _addressService.GetAll(cancellationToken);
        }

        /// <summary>
        /// Get address using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<AddressResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _addressService.Get(id, cancellationToken);
        }

        /// <summary>
        /// Create address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(AddressCreateModel address, CancellationToken cancellationToken)
        {
            var requestModel = address.Adapt<AddressRequestModel>();

            await _addressService.Create(requestModel, cancellationToken);
        }

        /// <summary>
        /// Update address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(AddressUpdateModel address, int id, CancellationToken cancellationToken)
        {
            var requestModel = address.Adapt<AddressRequestModel>();
            requestModel.Id = id;

            await _addressService.Update(requestModel, cancellationToken);
        }

        /// <summary>
        /// Delete address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _addressService.Delete(id, cancellationToken);
        }
    }
}
