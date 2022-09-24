using Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Devs.Application.Features.Developers.Commands.DeleteDeveloper;
using Devs.Application.Features.Developers.Commands.UpdateDeveloper;
using Devs.Application.Features.Developers.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateDeveloperCommand createDeveloperCommand)
        {
           CreatedDeveloperDto result =  await Mediator.Send(createDeveloperCommand);

           return Created("",result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteDeveloperCommand deleteDeveloperCommand)
        {
            DeletedDeveloperDto result = await Mediator.Send(deleteDeveloperCommand);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDeveloperCommand updateDeveloperCommand)
        {
            UpdatedDeveloperDto result = await Mediator.Send(updateDeveloperCommand);

            return Ok(result);
        }
    }
}
