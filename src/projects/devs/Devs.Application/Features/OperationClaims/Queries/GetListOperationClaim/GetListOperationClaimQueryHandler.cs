using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Models;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;

    public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
    }

    public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request,
        CancellationToken cancellationToken)
    {
        IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize, 
            cancellationToken: cancellationToken);

        OperationClaimListModel mappedList = _mapper.Map<OperationClaimListModel>(operationClaims);

        return mappedList;
    }
}