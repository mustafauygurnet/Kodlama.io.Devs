using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using Devs.Application.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Devs.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public UserOperationClaimBusinessRules(IAuthService authService, IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public async Task AuthorizedCheck()
    {
        int userId = _httpContextAccessor.HttpContext.User.GetUserId();

        if (userId == 0)
            throw new BusinessException("Please Login");

        var operationClaims = await _authService.FindOperationClaims(userId);

        var gmClaims = _configuration.GetSection("GMClaims").GetChildren().Select(g => g.Value).ToList();


        foreach (var claim in operationClaims)
        {
            if (gmClaims.Contains(claim.Name))
            {
                return;
            }
        }

        throw new AuthorizationException("you are not authorized");
    }
}