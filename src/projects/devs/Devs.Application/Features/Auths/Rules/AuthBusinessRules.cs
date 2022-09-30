using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;


    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null)
            throw new BusinessException("Mail already exists");
    }

    public async Task<User> EmailOrPasswordControlWhenLogged(string email, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        
        if (user is null)
            throw new BusinessException("Password or Email Wrong");

        bool verifyPassword = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
        
        if (!verifyPassword)
            throw new BusinessException("Password or Email Wrong");

        return user;
    }
}