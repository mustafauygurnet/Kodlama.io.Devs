using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;

public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request,
        CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimNameCanNotDuplicatedWhenInserted(request.Name);

        OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
        OperationClaim deletedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);

        UpdatedOperationClaimDto updatedOperationClaimDto =
            _mapper.Map<UpdatedOperationClaimDto>(deletedOperationClaim);

        return updatedOperationClaimDto;
    }
}