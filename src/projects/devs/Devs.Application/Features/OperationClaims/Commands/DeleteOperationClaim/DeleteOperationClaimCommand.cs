using Devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
{
    public int Id { get; set; }
}