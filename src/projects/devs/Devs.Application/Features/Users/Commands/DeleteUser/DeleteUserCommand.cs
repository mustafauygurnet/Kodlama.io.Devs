using Devs.Application.Features.Users.Dtos;
using MediatR;

namespace Devs.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeletedUserDto>
{
    public int Id { get; set; }
}