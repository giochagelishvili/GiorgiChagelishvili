using FluentValidation;
using Forum.API.Infrastructure.Localizations;
using Forum.Application.Accounts;

namespace Forum.API.Infrastructure.Validators.Accounts
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
