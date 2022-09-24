using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<IList<OperationClaim>> FindOperationClaimsForUser(IPaginate<UserOperationClaim> userOperationClaims)
    {
        List<OperationClaim> operationClaims = new List<OperationClaim>();

        foreach (var userOperationClaim in userOperationClaims.Items)
        {
            operationClaims.Add(_operationClaimRepository.Get(o => o.Id == userOperationClaim.OperationClaimId));
        }

        return operationClaims;
    }
}