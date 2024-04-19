using Application.Validations.Extentions;
using FluentValidation;
using VideoManager.Domain.Rules;

namespace VideoManager.API.Application.Commands.Validators;

public class CreateVideoCommandValidator : AbstractValidator<CreateVideoCommand>
{
    public CreateVideoCommandValidator()
    {
        RuleFor(x => x.Title).AdhereRule(title => new TitleLengthRule(title));
        RuleFor(x => x.Description).AdhereRule(description => new DescriptionLengthRule(description));
    }
}