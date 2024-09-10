using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Queries.DespesasQueries.GetAllDespesas;

namespace TCCLions.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DespesasController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var data = await _mediator.Send(new GetAllDespesasQuery());

        if (!data.Any())
            return NoContent();

        return Ok(data);
    }
}
