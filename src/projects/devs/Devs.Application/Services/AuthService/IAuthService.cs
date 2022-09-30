using Core.Security.Entities;
using Core.Security.JWT;

namespace Devs.Application.Services.AuthService;

public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
}