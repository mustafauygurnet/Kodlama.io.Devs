using Devs.Application.Features.Users.Commands.CreateUser;
using Devs.Application.Features.Users.Commands.LoginUser;
using Devs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserCommand)
        {
            CreatedUserForRegisterDto createdUserForRegisterDto = await Mediator.Send(createUserCommand);
            return Created("",createdUserForRegisterDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            LoginedUserDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}