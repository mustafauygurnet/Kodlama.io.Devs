using FluentValidation;

namespace Devs.Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageValidator : AbstractValidator<CreateLanguageCommand>
{
    public CreateLanguageValidator()
    {
        RuleFor(p=>p.Name).NotEmpty();
        RuleFor(p=>p.Name).NotNull();
    }
}