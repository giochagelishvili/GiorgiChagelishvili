using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null || result.Count <= 0)
                throw new OrderNotFoundException();

            return result.Adapt<List<OrderResponseModel>>();
        }

        public async Task<OrderResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new OrderNotFoundException();

            var result = await _repository.Get(id, cancellationToken);

            return result.Adapt<OrderResponseModel>();
        }

        public async Task Create(OrderRequestModel order, CancellationToken cancellationToken)
        {
            var orderToInsert = order.Adapt<Order>();

            await _repository.Create(orderToInsert, cancellationToken);
        }
    }
}
