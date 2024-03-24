using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Pizzas;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// Get all pizzas from the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _pizzaService.GetAll(cancellationToken);
        }

        /// <summary>
        /// Get pizza using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<PizzaResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _pizzaService.Get(id, cancellationToken);
        }

        /// <summary>
        /// Create pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(PizzaCreateModel pizza, CancellationToken cancellationToken)
        {
            var requestModel = pizza.Adapt<RankHistoryRequestModel>();

            await _pizzaService.Create(requestModel, cancellationToken);
        }

        /// <summary>
        /// Update pizza information
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task Put(PizzaCreateModel pizza, int id, CancellationToken cancellationToken)
        {
            var requestModel = pizza.Adapt<RankHistoryRequestModel>();
            requestModel.Id = id;

            await _pizzaService.Update(requestModel, cancellationToken);
        }

        /// <summary>
        /// Update pizza price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public async Task Put(int id, decimal price, CancellationToken cancellationToken)
        {
            await _pizzaService.UpdatePrice(id, price, cancellationToken);
        }

        /// <summary>
        /// Delete pizza
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _pizzaService.Delete(id, cancellationToken);
        }
    }
}
