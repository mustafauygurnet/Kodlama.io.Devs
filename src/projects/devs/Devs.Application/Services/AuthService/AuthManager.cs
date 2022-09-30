using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Devs.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        var userClaims = await
            _userOperationClaimRepository.GetListAsync
            (predicate: u => u.UserId == user.Id,
                include: u => u.Include(c => c.OperationClaim)
            );
        
        IList<OperationClaim> operationClaims =
            userClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, 
                    Name = u.OperationClaim.Name 
                }).ToList();

        AccessToken createdAccessToken = _tokenHelper.CreateToken(user,operationClaims);

        return createdAccessToken;

    }

    public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken createdRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return await Task.FromResult(createdRefreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
}