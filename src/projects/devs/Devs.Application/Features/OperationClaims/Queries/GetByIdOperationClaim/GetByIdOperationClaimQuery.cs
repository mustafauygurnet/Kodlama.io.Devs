using Devs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimDto>
{
    public int Id { get; set; }
}