namespace PizzaProject.Application.Orders
{
    public interface IOrderService
    {
        Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<OrderResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(OrderRequestModel order, CancellationToken cancellationToken);
    }
}
