using Devs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}