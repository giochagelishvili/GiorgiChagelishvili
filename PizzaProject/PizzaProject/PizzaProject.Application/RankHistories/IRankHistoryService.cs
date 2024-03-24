namespace PizzaProject.Application.RankHistories
{
    public interface IRankHistoryService
    {
        Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<RankHistoryResponseModel> Get(int id, CancellationToken cancellationToken);
        Task Create(RankHistoryRequestModel rankHistory, CancellationToken cancellationToken);
    }
}
