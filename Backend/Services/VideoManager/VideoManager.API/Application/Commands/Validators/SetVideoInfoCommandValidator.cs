using Application.Validations.Extentions;
using FluentValidation;
using VideoManager.Domain.Rules;

namespace VideoManager.API.Application.Commands.Validators;

public class SetVideoInfoCommandValidator : AbstractValidator<SetVideoInfoCommand>
{
    public SetVideoInfoCommandValidator()
    {
        RuleFor(x => x.SetVideoBasicInfo!).SetValidator(new BasicInfoValidator());
        RuleFor(x => x.SetVideoVisibilityInfo!).SetValidator(new VisibilityValidator());
    }

    public class BasicInfoValidator : AbstractValidator<SetVideoBasicInfoCommand>
    {
        public BasicInfoValidator()
        {
            RuleFor(x => x.Title).AdhereRule(title => new TitleLengthRule(title));
            RuleFor(x => x.Description).AdhereRule(description => new DescriptionLengthRule(description));
            RuleFor(x => x.Tags).AdhereRule(tags => new TagsLengthRule(tags));
        }
    }

    public class VisibilityValidator : AbstractValidator<SetVideoVisibilityInfoCommand>
    {
        public VisibilityValidator()
        {
            RuleFor(x => x.Visibility).AdhereRule(visibility => new ValidVideoVisibilityRule(visibility));
        }
    }
}
