using Core.Security.JWT;

namespace Devs.Application.Features.Users.Dtos;

public class LoginedUserDto
{
    public string Email { get; set; }
    public AccessToken AccessToken { get; set; }
}