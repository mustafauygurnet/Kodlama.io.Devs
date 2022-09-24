using Core.Application.Requests;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Models;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }
}