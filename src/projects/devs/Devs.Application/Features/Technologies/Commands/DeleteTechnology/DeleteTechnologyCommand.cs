using Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
{
    public int Id { get; set; }
}