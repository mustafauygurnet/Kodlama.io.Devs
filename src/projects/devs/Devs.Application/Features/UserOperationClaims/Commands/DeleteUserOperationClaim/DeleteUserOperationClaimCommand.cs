using Devs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
{
    public int Id { get; set; }
}