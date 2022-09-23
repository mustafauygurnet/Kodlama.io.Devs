using Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
}