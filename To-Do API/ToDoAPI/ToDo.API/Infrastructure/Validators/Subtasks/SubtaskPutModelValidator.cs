using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.Subtasks;

namespace ToDo.API.Infrastructure.Validators.Subtasks
{
    public class SubtaskPutModelValidator : AbstractValidator<SubtaskPutModel>
    {
        public SubtaskPutModelValidator() 
        {
            RuleFor(subtask => subtask.Title)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage(ErrorMessages.InvalidTitle);
        }
    }
}
