using FluentValidation;
using Forum.Application.Accounts;
using Forum.Web.Infrastructure.Localizations;

namespace Forum.Web.Infrastructure.Validators.Accounts
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
