using FluentValidation;
using Forum.Application.Accounts.Updates;
using Forum.Web.Infrastructure.Localizations;

namespace Forum.Web.Infrastructure.Validators.Updates
{
    public class EmailRequestPutModelValidator : AbstractValidator<EmailRequestPutModel>
    {
        public EmailRequestPutModelValidator()
        {
            RuleFor(model => model.Email)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmailRequired)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage(ErrorMessages.InvalidEmailFormat);
        }
    }
}
