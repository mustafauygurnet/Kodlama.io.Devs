using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.Auths.Dtos;
using Devs.Application.Features.Auths.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Auths.Commands.CreateRegister;

public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand, RegisteredDto>
{
    private IUserRepository _userRepository;
    private IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;

    public CreateRegisterCommandHandler(IAuthService authService, IUserRepository userRepository,
        AuthBusinessRules authBusinessRules, IMapper mapper)
    {
        _authService = authService;
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
    }

    public async Task<RegisteredDto> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);

        HashingHelper.CreatePasswordHash
            (request.UserForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        User mappedUser = _mapper.Map<User>(request.UserForRegisterDto);

        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;
        mappedUser.Status = true;

        User addedUser = await _userRepository.AddAsync(mappedUser);
        
        AccessToken createdAccessToken = await _authService.CreateAccessToken(addedUser);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(addedUser, request.IpAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RegisteredDto registeredDto = new RegisteredDto
        {
            RefreshToken = addedRefreshToken,
            AccessToken = createdAccessToken,
        };
        return registeredDto;
        
    }
}