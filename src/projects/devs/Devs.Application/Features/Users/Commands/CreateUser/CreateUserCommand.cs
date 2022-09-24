using Core.Persistence.Paging;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Features.Users.Dtos;
using MediatR;

namespace Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserForRegisterDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}