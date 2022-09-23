using Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public int LanguageId { get; set; }
    public string Name { get; set; }
}