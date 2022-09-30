using Core.Security.Dtos;
using Devs.Application.Features.Auths.Dtos;
using MediatR;

namespace Devs.Application.Features.Auths.Commands.CreateRegister;

public class CreateRegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }
}