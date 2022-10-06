using Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand userOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(userOperationClaimCommand);

        return Created("", result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand userOperationClaimCommand)
    {
        UpdatedUserOperationClaimDto result = await Mediator.Send(userOperationClaimCommand);

        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand userOperationClaimCommand)
    {
        DeletedUserOperationClaimDto result = await Mediator.Send(userOperationClaimCommand);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByUserIdOperationClaims(
        [FromQuery] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
    {
        GetByUserIdUserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
        return Ok(result);
    }
}