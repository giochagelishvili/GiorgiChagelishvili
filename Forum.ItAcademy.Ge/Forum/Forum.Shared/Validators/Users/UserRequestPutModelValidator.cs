using FluentValidation;
using Forum.Application.Profiles.Requests.Updates;
using Forum.Shared.Localizations;

namespace Forum.Shared.Validators.Users
{
    public class UserRequestPutModelValidator : AbstractValidator<UserRequestPutModel>
    {
        public UserRequestPutModelValidator()
        {
            RuleFor(model => model.Email)
                .NotEmpty().When(model => model.Email != null)
                .WithMessage(ErrorMessages.EmailRequired)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .When(model => model.Email != null)
                .WithMessage(ErrorMessages.InvalidEmailFormat);

            RuleFor(model => model.UpdatedUsername)
                .NotEmpty().When(model => model.Email != null)
                .WithMessage(ErrorMessages.UsernameRequired)
                .MaximumLength(50).When(model => model.UpdatedUsername != null)
                .WithMessage(ErrorMessages.UsernameMaxLength);

            RuleFor(model => model.CurrentPassword)
                .NotEmpty().When(model => model.CurrentPassword != null && model.NewPassword != null)
                .WithMessage(ErrorMessages.BothPasswordsRequired);

            RuleFor(model => model.NewPassword)
                .NotEmpty().When(model => model.NewPassword != null && model.CurrentPassword != null)
                .WithMessage(ErrorMessages.BothPasswordsRequired)
                .MaximumLength(30).When(model => model.NewPassword != null)
                .WithMessage(ErrorMessages.PasswordMaxLength)
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$")
                .When(model => model.NewPassword != null)
                .WithMessage(ErrorMessages.InvalidPasswordFormat);

            RuleFor(model => model.ConfirmPassword)
                .NotEmpty().When(model => model.ConfirmPassword != null && model.NewPassword != null)
                .WithMessage(ErrorMessages.ConfirmPasswordRequired)
                .Equal(model => model.NewPassword)
                .WithMessage(ErrorMessages.PasswordsDoNotMatch);
        }
    }
}
