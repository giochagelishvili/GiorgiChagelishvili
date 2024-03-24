using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Pizzas
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null || result.Count <= 0)
                throw new PizzaNotFoundException();

            return result.Adapt<List<PizzaResponseModel>>();
        }

        public async Task<PizzaResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            var result = await _repository.Get(id, cancellationToken);

            if (result == null)
                throw new PizzaNotFoundException();

            return result.Adapt<PizzaResponseModel>();
        }

        public async Task Create(RankHistoryRequestModel pizza, CancellationToken cancellationToken)
        {
            var pizzaToInsert = pizza.Adapt<Pizza>();

            await _repository.Create(pizzaToInsert, cancellationToken);
        }

        public async Task Update(RankHistoryRequestModel pizza, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(pizza.Id, cancellationToken))
                throw new PizzaNotFoundException();

            var pizzaToUpdate = pizza.Adapt<Pizza>();

            await _repository.Update(pizzaToUpdate, cancellationToken);
        }

        public async Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new PizzaNotFoundException();

            await _repository.UpdatePrice(id, price, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await _repository.Exists(id, cancellationToken))
                throw new PizzaNotFoundException();

            await _repository.Delete(id, cancellationToken);
        }
    }
}
