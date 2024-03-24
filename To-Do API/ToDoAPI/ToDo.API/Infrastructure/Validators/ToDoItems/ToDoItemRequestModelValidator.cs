using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.API.Infrastructure.Models.ToDoItems;

namespace ToDo.API.Infrastructure.Validators.ToDoItems
{
    public class ToDoItemRequestModelValidator : AbstractValidator<ToDoItemPutModel>
    {
        public ToDoItemRequestModelValidator()
        {
            RuleFor(toDoItem => toDoItem.Title)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidTitle);

            RuleFor(toDoItem => toDoItem.TargetCompletionDate)
                .NotEmpty()
                .WithMessage(ErrorMessages.CompletionDateRequired);
        }
    }
}
