using Core.Security.Entities;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using Devs.Application.Services.UserService;
using MediatR;

namespace Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;

public class GetByIdUserOperationClaimQuery : IRequest<GetByUserIdUserOperationClaimDto>
{
    public int Id { get; set; }
}

public class
    GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery,
        GetByUserIdUserOperationClaimDto>
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;


    public GetByIdUserOperationClaimQueryHandler(IAuthService authService, IUserService userService,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _authService = authService;
        _userService = userService;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<GetByUserIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request,
        CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.AuthorizedCheck();
        
        var operationClaims = await _authService.FindOperationClaims(request.Id);
        User user = await _userService.FindUser(request.Id);

        GetByUserIdUserOperationClaimDto resultDto = new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Claims = new List<OperationClaim>(operationClaims)
        };

        return resultDto;
    }
}