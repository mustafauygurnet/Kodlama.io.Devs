using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Devs.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);

            return Created("", result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await Mediator.Send(updateTechnologyCommand);

            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery { PageRequest = pageRequest };

            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListById([FromQuery] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            GetByIdTechnologyDto result = await Mediator.Send(getByIdTechnologyQuery);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
            [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListTechnologyQuery = new GetListTechnologyByDynamicQuery
                { PageRequest = pageRequest, Dynamic = dynamic };

            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);

            return Ok(result);
        }
    }
}