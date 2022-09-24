using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
        OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request,
        CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimNameCanNotDuplicatedWhenInserted(request.Name);

        OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

        OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);

        CreatedOperationClaimDto createdOperationClaimDto =
            _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);

        return createdOperationClaimDto;
    }
}