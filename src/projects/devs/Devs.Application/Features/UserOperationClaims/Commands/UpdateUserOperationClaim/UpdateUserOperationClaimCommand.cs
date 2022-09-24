using Devs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}