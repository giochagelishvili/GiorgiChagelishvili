using FluentValidation;
using PizzaProject.API.Infrastructure.Localizations;
using PizzaProject.API.Models.Requests;

namespace PizzaProject.API.Infrastructure.Validators
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage(ErrorMessages.UserFirstNameEmpty)
                .Length(2, 20)
                .WithMessage(ErrorMessages.UserFirstNameInvalidLength);

            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage(ErrorMessages.UserLastNameEmpty)
                .Length(2, 30)
                .WithMessage(ErrorMessages.UserLastNameInvalidLength);

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmailEmpty)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage(ErrorMessages.EmailInvalid);

            RuleFor(user => user.PhoneNumber)
                .NotEmpty()
                .WithMessage(ErrorMessages.UserPhoneNumberEmpty)
                .Matches(@"^\d{9}$")
                .WithMessage(ErrorMessages.UserPhoneNumberInvalid);
        }
    }
}
