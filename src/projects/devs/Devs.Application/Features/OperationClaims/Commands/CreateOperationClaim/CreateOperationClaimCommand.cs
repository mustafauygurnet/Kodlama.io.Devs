using Devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
{
    public string Name { get; set; }
}