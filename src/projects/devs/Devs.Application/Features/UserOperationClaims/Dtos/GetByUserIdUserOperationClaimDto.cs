using Core.Security.Entities;

namespace Devs.Application.Features.UserOperationClaims.Dtos;

public class GetByUserIdUserOperationClaimDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<OperationClaim> Claims { get; set; }
}