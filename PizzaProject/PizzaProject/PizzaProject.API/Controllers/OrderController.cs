using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Orders;

namespace PizzaProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Get all orders from the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _orderService.GetAll(cancellationToken);
        }

        /// <summary>
        /// Get order using ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<OrderResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _orderService.Get(id, cancellationToken);
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post(OrderCreateModel order, CancellationToken cancellationToken)
        {
            var requestModel = order.Adapt<OrderRequestModel>();

            await _orderService.Create(requestModel, cancellationToken);
        }
    }
}
