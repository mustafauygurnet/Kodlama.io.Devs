using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Services.UserService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> FindUser(int userId)
    {
        User? user =  await _userRepository.GetAsync(u=>u.Id == userId);
        if (user is null)
        {
            throw new BusinessException("User not Found");
        }
        return user;
    }
    
    public async Task<User> FindUser(string email)
    {
        User? user =  await _userRepository.GetAsync(u=>u.Email == email);
        if (user is null)
        {
            throw new BusinessException("User not Found");
        }
        return user;
    }
}