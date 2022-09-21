using FluentValidation;

namespace Devs.Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageCommand>
{
    public UpdateLanguageValidator()
    {
        RuleFor(up => up.Name).NotEmpty();
        RuleFor(up => up.Name).NotNull();
    }
}