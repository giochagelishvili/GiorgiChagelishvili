
using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.RankHistories
{
    public class RankHistoryService : IRankHistoryService
    {
        private readonly IRankHistoryRepository _repository;

        public RankHistoryService(IRankHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null || result.Count <= 0)
                throw new RankNotFoundException();

            return result.Adapt<List<RankHistoryResponseModel>>();
        }

        public async Task Create(RankHistoryRequestModel rankHistory, CancellationToken cancellationToken)
        {
            var rankToInsert = rankHistory.Adapt<RankHistory>();

            await _repository.Create(rankToInsert, cancellationToken);
        }

        public async Task<RankHistoryResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new RankNotFoundException();

            var result = await _repository.Get(id, cancellationToken);

            return result.Adapt<RankHistoryResponseModel>();
        }
    }
}
