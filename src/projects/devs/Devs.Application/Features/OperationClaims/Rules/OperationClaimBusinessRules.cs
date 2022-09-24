using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;

namespace Devs.Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<IList<OperationClaim>> FindOperationClaimsForUser(
        IPaginate<UserOperationClaim> userOperationClaims)
    {
        List<OperationClaim> operationClaims = new List<OperationClaim>();

        foreach (var userOperationClaim in userOperationClaims.Items)
        {
            operationClaims.Add(_operationClaimRepository.Get(o => o.Id == userOperationClaim.OperationClaimId));
        }

        return operationClaims;
    }


    public async Task OperationClaimNameCanNotDuplicatedWhenInserted(string operationClaimName)
    {
        IPaginate<OperationClaim> result =
            await _operationClaimRepository.GetListAsync(predicate: o => o.Name == operationClaimName);

        if (result.Items.Any()) throw new BusinessException("Operation Claim Name already exits");
    }

    public async Task OperationClaimShouldExistsWhenRequested(int operationClaimId)
    {
        OperationClaim? result = await _operationClaimRepository.GetAsync(b => b.Id == operationClaimId);
        if (result is null) throw new BusinessException("Requested OperationClaim Does not Exists");
    }
}