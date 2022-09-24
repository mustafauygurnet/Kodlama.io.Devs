using Devs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimDto>
{
    public int Id { get; set; }
}