using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class RankHistoryCreateModelValidator : AbstractValidator<RankHistoryCreateModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public RankHistoryCreateModelValidator(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;

            RuleFor(rankHistory => rankHistory.PizzaId)
                .NotEmpty()
                .WithMessage(ErrorMessages.RankHistoryPizzaIdRequired)
                .Must((rankHistory, pizzaId) => UserOrderedPizza(rankHistory.UserId, pizzaId, new CancellationToken()))
                .WithMessage(ErrorMessages.RankHistoryInvalidPizzaId);

            RuleFor(rankHistory => rankHistory.UserId)
                .NotEmpty()
                .WithMessage(ErrorMessages.RankHistoryUserIdRequired)
                .Must(userId => UserExists(userId, new CancellationToken()))
                .WithMessage(ErrorMessages.UserNotFound);

            RuleFor(rankHistory => rankHistory.Rank)
                .NotEmpty()
                .WithMessage(ErrorMessages.RankIsRequired)
                .InclusiveBetween(1, 10)
                .WithMessage(ErrorMessages.InvalidRank);
        }

        private bool UserExists(int userId, CancellationToken cancellationToken)
        {
            return _userRepository.Exists(userId, cancellationToken).Result;
        }

        private bool UserOrderedPizza(int userId, int pizzaId, CancellationToken cancellationToken)
        {
            if (!_userRepository.Exists(userId, cancellationToken).Result)
                throw new UserNotFoundException();

            if (!_orderRepository.UserOrderedPizza(userId, pizzaId, cancellationToken).Result)
                return false;

            return true;
        }
    }
}
