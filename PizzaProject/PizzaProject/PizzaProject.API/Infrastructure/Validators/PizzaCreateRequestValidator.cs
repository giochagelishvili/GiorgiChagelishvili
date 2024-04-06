using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class PizzaCreateRequestValidator : AbstractValidator<PizzaCreateModel>
    {
        public PizzaCreateRequestValidator()
        {
            RuleFor(pizza => pizza.Name)
                .NotEmpty()
                .WithMessage(ErrorMessages.PizzaNameEmpty)
                .Length(3, 20)
                .WithMessage(ErrorMessages.PizzaNameInvalidLength);

            RuleFor(pizza => pizza.Price)
                .NotEmpty()
                .WithMessage(ErrorMessages.PizzaPriceEmpty)
                .GreaterThan(0)
                .WithMessage(ErrorMessages.PizzaPriceInvalid);

            RuleFor(pizza => pizza.Description)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.PizzaInvalidDescriptionLength);

            RuleFor(pizza => pizza.CaloryCount)
                .NotEmpty()
                .WithMessage(ErrorMessages.PizzaCaloryCountEmpty)
                .GreaterThan(0)
                .WithMessage(ErrorMessages.PizzaCaloryCountInvalid);
        }
    }
}
