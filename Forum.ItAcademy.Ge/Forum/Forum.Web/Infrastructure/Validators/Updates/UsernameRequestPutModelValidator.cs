using FluentValidation;
using Forum.Application.Accounts.Updates;
using Forum.Web.Infrastructure.Localizations;

namespace Forum.Web.Infrastructure.Validators.Updates
{
    public class UsernameRequestPutModelValidator : AbstractValidator<UsernameRequestPutModel>
    {
        public UsernameRequestPutModelValidator()
        {
            RuleFor(model => model.Username)
                .NotEmpty()
                .WithMessage(ErrorMessages.UsernameRequired)
                .MaximumLength(50)
                .WithMessage(ErrorMessages.UsernameMaxLength);
        }
    }
}
