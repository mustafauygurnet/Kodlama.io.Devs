using Devs.Application.Features.Languages.Dtos;
using MediatR;

namespace Devs.Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
{
    public int Id { get; set; }
}