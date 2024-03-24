using FluentValidation;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.ToDos.Requests;

namespace ToDo.API.Infrastructure.Validators.ToDoItems
{
    public class ToDoItemRequestPostModelValidator : AbstractValidator<ToDoItemRequestPostModel>
    {
        public ToDoItemRequestPostModelValidator()
        {
            RuleFor(toDoItem => toDoItem.Title)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage(ErrorMessages.InvalidTitle);
        }
    }
}
