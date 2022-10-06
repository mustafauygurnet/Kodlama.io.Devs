using Core.Security.Entities;

namespace Devs.Application.Services.UserService;

public interface IUserService
{
    Task<User> FindUser(int userId);
    Task<User> FindUser(string email);
}