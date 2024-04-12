using FluentValidation;
using Forum.Shared.Localizations;
using Forum.Shared.Models.Topics;

namespace Forum.Shared.Validators.Topics
{
    public class TopicRequestPresentationModelValidator : AbstractValidator<TopicRequestPresentationModel>
    {
        public TopicRequestPresentationModelValidator()
        {
            RuleFor(model => model.Title)
                .NotEmpty()
                .WithMessage(ErrorMessages.TitleRequired)
                .MaximumLength(50)
                .WithMessage(ErrorMessages.TitleMaxLength);

            RuleFor(model => model.Description)
                .NotEmpty()
                .WithMessage(ErrorMessages.DescriptionRequired);
        }
    }
}
