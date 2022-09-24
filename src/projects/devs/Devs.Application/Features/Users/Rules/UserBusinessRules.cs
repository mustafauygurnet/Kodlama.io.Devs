using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Devs.Application.Services.Repositories;
using MediatR;

namespace Devs.Application.Features.Users.Rules;

public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task PasswordCheck(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        bool passwordCheck = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);

        if (!passwordCheck)
        {
            throw new BusinessException("Password wrong!");
        }
    }

    public async Task EmailCheck(User user)
    {
        if (user is null)
        {
            throw new BusinessException("User not found");
        }
    }
}