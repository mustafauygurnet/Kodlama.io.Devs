using Devs.Application.Features.Developers.Dtos;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.DeleteDeveloper;

public class DeleteDeveloperCommand : IRequest<DeletedDeveloperDto>
{
    public int Id { get; set; }
}