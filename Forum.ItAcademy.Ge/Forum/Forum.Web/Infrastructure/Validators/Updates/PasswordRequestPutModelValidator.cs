using FluentValidation;
using Forum.Application.Accounts.Updates;
using Forum.Web.Infrastructure.Localizations;

namespace Forum.Web.Infrastructure.Validators.Updates
{
    public class PasswordRequestPutModelValidator : AbstractValidator<PasswordRequestPutModel>
    {
        public PasswordRequestPutModelValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage(ErrorMessages.PasswordRequired);

            RuleFor(model => model.Password)
                .NotEmpty()
                .WithMessage(ErrorMessages.PasswordRequired)
                .MinimumLength(6)
                .WithMessage(ErrorMessages.PasswordMinLength)
                .MaximumLength(30)
                .WithMessage(ErrorMessages.PasswordMaxLength)
                .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s]).{6,}$")
                .WithMessage(ErrorMessages.InvalidPasswordFormat);

            RuleFor(model => model.ConfirmPassword)
                .Equal(model => model.Password)
                .WithMessage(ErrorMessages.PasswordsDoNotMatch);
        }
    }
}
