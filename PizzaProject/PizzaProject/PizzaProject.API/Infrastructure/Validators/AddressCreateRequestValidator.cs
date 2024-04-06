using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Repositories;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class AddressCreateRequestValidator : AbstractValidator<AddressCreateModel>
    {
        private readonly IUserRepository _userRepository;

        public AddressCreateRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(address => address.UserId)
                .Must(userId => UserIdExists(userId, new CancellationToken()))
                .WithMessage(ErrorMessages.AddressUserIdDoesNotExist);

            RuleFor(address => address.City)
                .NotEmpty()
                .WithMessage(ErrorMessages.AddressCityEmpty)
                .MaximumLength(15)
                .WithMessage(ErrorMessages.AddressCityLengthInvalid);

            RuleFor(address => address.Country)
                .NotEmpty()
                .WithMessage(ErrorMessages.AddressCountryEmpty)
                .MaximumLength(15)
                .WithMessage(ErrorMessages.AddressCountryLengthInvalid);

            RuleFor(address => address.Region)
                .MaximumLength(15)
                .WithMessage(ErrorMessages.AddressRegionLengthInvalid);

            RuleFor(address => address.Description)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.AddressDescriptionLengthInvalid);
        }

        private bool UserIdExists(int userId, CancellationToken cancellationToken)
        {
            return _userRepository.Exists(userId, cancellationToken).Result;
        }
    }
}