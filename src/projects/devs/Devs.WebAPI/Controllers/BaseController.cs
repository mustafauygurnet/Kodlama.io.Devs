using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebAPI.Controllers;

public class BaseController : ControllerBase
{
    public IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}