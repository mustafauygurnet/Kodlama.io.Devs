using Devs.Application.Features.Developers.Dtos;
using MediatR;

namespace Devs.Application.Features.Developers.Commands.UpdateDeveloper;

public class UpdateDeveloperCommand : IRequest<UpdatedDeveloperDto>
{
    public string GithubAddress { get; set; }
}