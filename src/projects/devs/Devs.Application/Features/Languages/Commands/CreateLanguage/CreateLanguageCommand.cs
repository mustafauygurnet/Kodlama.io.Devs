using Devs.Application.Features.Languages.Dtos;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageCommand : IRequest<CreatedLanguageDto>
{
    public string Name { get; set; }
}