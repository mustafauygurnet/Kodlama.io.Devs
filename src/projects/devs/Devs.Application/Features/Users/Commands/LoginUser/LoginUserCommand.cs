using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Features.Users.Rules;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommand : IRequest<LoginedUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginedUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
    private readonly UserBusinessRules _userBusinessRules;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<LoginedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == request.Email);

        await _userBusinessRules.EmailCheck(user);

        await _userBusinessRules.PasswordCheck(request.Password, user.PasswordHash, user.PasswordSalt);

        IList<OperationClaim> claims = await _userOperationClaimBusinessRules.FindOperationClaimForUser(user.Id);

        AccessToken accessToken = _tokenHelper.CreateToken(user, claims);


        LoginedUserDto loginedUserDto = _mapper.Map<LoginedUserDto>(user);

        loginedUserDto.AccessToken = accessToken;

        return loginedUserDto;
    }
}