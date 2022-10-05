using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Features.Auths.Dtos;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Services.AuthService;
using MediatR;

namespace Devs.Application.Features.Auths.Commands.Logins;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
{
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;


    public LoginCommandHandler(AuthBusinessRules authBusinessRules,
        IAuthService authService)
    {
        _authBusinessRules = authBusinessRules;
        _authService = authService;
    }

    public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User user = await _authBusinessRules.EmailOrPasswordControlWhenLogged(request.UserForLoginDto.Email, request.UserForLoginDto.Password);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        return new LoggedDto
        {
            AccessToken = createdAccessToken,
            RefreshToken = addedRefreshToken
        };
    }
}