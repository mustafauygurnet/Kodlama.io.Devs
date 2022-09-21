using Core.Application.Requests;
using Devs.Application.Features.Languages.Commands.CreateLanguage;
using Devs.Application.Features.Languages.Commands.DeleteLanguage;
using Devs.Application.Features.Languages.Commands.UpdateLanguage;
using Devs.Application.Features.Languages.Dtos;
using Devs.Application.Features.Languages.Queries.Languages.GetByIdLanguage;
using Devs.Application.Features.Languages.Queries.Languages.GetListLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
    {
        var result = await Mediator.Send(createLanguageCommand);
        return Created("", result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };

        var result = await Mediator.Send(getListLanguageQuery);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
    {
        GetByIdLanguageDto result = await Mediator.Send(getByIdLanguageQuery);
        return Ok(result);
    }
    
    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
    {
        UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);

        return Ok(result);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand)
    {
        DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);

        return Ok(result);
    }
}