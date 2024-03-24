using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.ToDoItems;

namespace ToDo.API.Infrastructure.Validators.ToDoItems
{
    public class ToDoItemPatchModelValidator : AbstractValidator<ToDoItemPatchModel>
    {
        public ToDoItemPatchModelValidator()
        {
            RuleFor(toDoItem => toDoItem.Title)
                .NotEmpty()
                .When(toDoItem => toDoItem.TargetCompletionDate == null)
                .WithMessage(ErrorMessages.InvalidPatchModel);

            RuleFor(toDoItem => toDoItem.TargetCompletionDate)
                .NotNull()
                .When(toDoItem => string.IsNullOrEmpty(toDoItem.Title))
                .WithMessage(ErrorMessages.InvalidPatchModel);
        }
    }
}
