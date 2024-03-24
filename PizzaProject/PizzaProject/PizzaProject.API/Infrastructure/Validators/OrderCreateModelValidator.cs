using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Repositories;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class OrderCreateModelValidator : AbstractValidator<OrderCreateModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IAddressRepository _addressRepository;

        public OrderCreateModelValidator(IUserRepository userRepository, IPizzaRepository pizzaRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
            _addressRepository = addressRepository;

            RuleFor(order => order.UserId)
                .NotEmpty()
                .WithMessage(ErrorMessages.OrderUserIdEmpty)
                .Must(userId => UserIdExists(userId, new CancellationToken()))
                .WithMessage(ErrorMessages.UserNotFound);

            RuleFor(order => order.AddressId)
                .Must((order, addressId) => AddressExistsForUser(order.UserId, addressId, new CancellationToken()))
                .WithMessage(ErrorMessages.AddressDoesNotExist);

            RuleFor(order => order.PizzaIds)
                .NotEmpty()
                .WithMessage(ErrorMessages.OrderPizzaListEmpty)
                .Must(pizzas => PizzasExist(pizzas, new CancellationToken()))
                .WithMessage(ErrorMessages.PizzaNotFound);

        }

        private bool AddressExistsForUser(int userId, int? addressId, CancellationToken cancellationToken)
        {
            if (addressId == null || _addressRepository.AddressExistsForUser(userId, addressId, cancellationToken).Result)
                return true;

            return false;
        }

        private bool PizzasExist(List<int> pizzas, CancellationToken cancellationToken)
        {
            foreach (int pizzaId in pizzas)
                if (_pizzaRepository.Exists(pizzaId, cancellationToken).Result == false)
                    return false;

            return true;
        }

        private bool UserIdExists(int userId, CancellationToken cancellationToken)
        {
            return _userRepository.Exists(userId, cancellationToken).Result;
        }
    }
}
