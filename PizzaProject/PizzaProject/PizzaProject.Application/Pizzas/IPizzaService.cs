namespace PizzaProject.Application.Pizzas
{
    public interface IPizzaService
    {
        Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<PizzaResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(RankHistoryRequestModel pizza, CancellationToken cancellationToken);
        Task Update(RankHistoryRequestModel pizza, CancellationToken cancellationToken);
        Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
