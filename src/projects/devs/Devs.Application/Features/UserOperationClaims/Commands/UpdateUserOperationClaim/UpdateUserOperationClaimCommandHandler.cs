using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class
    UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
        UpdatedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request,
        CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.AuthorizedCheck();
        
        UserOperationClaim mappedOperationClaim = _mapper.Map<UserOperationClaim>(request);
        UserOperationClaim updatedUserOperationClaim =
            await _userOperationClaimRepository.AddAsync(mappedOperationClaim);

        UpdatedUserOperationClaimDto updatedUserOperationClaimDto =
            _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);

        return updatedUserOperationClaimDto;
    }
}