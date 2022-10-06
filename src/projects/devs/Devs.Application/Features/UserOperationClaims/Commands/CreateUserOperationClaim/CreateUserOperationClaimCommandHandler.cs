using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class
    CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
        CreatedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request,
        CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.AuthorizedCheck();
        
        UserOperationClaim mappedOperationClaim = _mapper.Map<UserOperationClaim>(request);
        UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedOperationClaim);

        CreatedUserOperationClaimDto createdUserOperationClaimDto =
            _mapper.Map<CreatedUserOperationClaimDto>(addedUserOperationClaim);

        return createdUserOperationClaimDto;
    }
}