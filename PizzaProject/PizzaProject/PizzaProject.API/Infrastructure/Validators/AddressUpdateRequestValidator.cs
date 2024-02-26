using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class AddressUpdateRequestValidator : AbstractValidator<AddressUpdateModel>
    {
        public AddressUpdateRequestValidator()
        {
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
    }
}
