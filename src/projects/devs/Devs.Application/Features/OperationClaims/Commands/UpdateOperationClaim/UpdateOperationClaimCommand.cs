using Devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}