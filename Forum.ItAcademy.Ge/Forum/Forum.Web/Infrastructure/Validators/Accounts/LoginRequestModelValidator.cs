using FluentValidation;
using Forum.Web.Infrastructure.Localizations;
using Forum.Application.Accounts.Requests;

namespace Forum.API.Infrastructure.Validators
{
    public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginRequestModelValidator()
        {
            RuleFor(model => model.Username)
                .NotEmpty()
                .WithMessage(ErrorMessages.UsernameRequired);

            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage(ErrorMessages.PasswordRequired);
        }
    }
}
