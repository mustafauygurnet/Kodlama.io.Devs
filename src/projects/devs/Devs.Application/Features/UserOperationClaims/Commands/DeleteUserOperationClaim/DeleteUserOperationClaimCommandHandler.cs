using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class
    DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
        DeletedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
        CancellationToken cancellationToken)
    {
        UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
        UserOperationClaim deletedUserOperationClaim =
            await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);

        DeletedUserOperationClaimDto deletedUserOperationClaimDto =
            _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);

        return deletedUserOperationClaimDto;
    }
}