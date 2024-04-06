using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.Subtasks.Requests;

namespace ToDo.API.Infrastructure.Validators.Subtasks
{
    public class SubtaskRequestPostModelValidator : AbstractValidator<SubtaskRequestPostModel>
    {
        public SubtaskRequestPostModelValidator()
        {
            RuleFor(subtask => subtask.Title)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidTitle);
        }
    }
}
