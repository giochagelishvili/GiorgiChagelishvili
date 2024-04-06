using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.Users.Requests;

namespace ToDo.API.Infrastructure.Validators
{
    public class UserRequestPostModelValidator : AbstractValidator<UserRequestPostModel>
    {
        public UserRequestPostModelValidator()
        {
            RuleFor(user => user.Username)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidUsername);

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidPassword);
        }
    }
}
