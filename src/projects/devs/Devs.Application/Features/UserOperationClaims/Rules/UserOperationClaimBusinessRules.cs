using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Rules;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository,
        OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<IList<OperationClaim>> FindOperationClaimForUser(int userId)
    {
        IPaginate<UserOperationClaim>
            result = await _userOperationClaimRepository.GetListAsync(u => u.UserId == userId);

        IList<OperationClaim> claims = await _operationClaimBusinessRules.FindOperationClaimsForUser(result);

        return claims;
    }
}