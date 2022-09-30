using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.Auths.Commands.CreateRegister;
using Devs.Application.Features.Auths.Commands.Logins;
using Devs.Application.Features.Auths.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            CreateRegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);

            SetRefreshTokenToCookie(result.RefreshToken);

            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new();
            loginCommand.UserForLoginDto = userForLoginDto;
            LoggedDto result = await Mediator.Send(loginCommand);

            return Ok(result);
        }
    }
}