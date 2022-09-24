using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Features.Users.Dtos;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserForRegisterDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<CreatedUserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        User createdUser = await _userRepository.AddAsync(user);

        var claims = await _userOperationClaimBusinessRules.FindOperationClaimForUser(user.Id);


        AccessToken createdAccessToken = _tokenHelper.CreateToken(createdUser,claims);


        CreatedUserForRegisterDto createdUserForRegisterDto = _mapper.Map<CreatedUserForRegisterDto>(createdUser);

        createdUserForRegisterDto.AccessToken = createdAccessToken;

        return createdUserForRegisterDto;
    }
}