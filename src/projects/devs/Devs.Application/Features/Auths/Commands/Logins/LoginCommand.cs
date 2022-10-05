using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Devs.Application.Features.Auths.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Auths.Commands.Logins;

public class LoginCommand : IRequest<LoggedDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }
}