using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;

public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
        OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<GetByIdOperationClaimDto> Handle(GetByIdOperationClaimQuery request,
        CancellationToken cancellationToken)
    {

        await _operationClaimBusinessRules.OperationClaimShouldExistsWhenRequested(request.Id);

        OperationClaim? mappedOperationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);

        GetByIdOperationClaimDto getByIdOperationClaimDto = _mapper.Map<GetByIdOperationClaimDto>(mappedOperationClaim);

        return getByIdOperationClaimDto;
    }
}