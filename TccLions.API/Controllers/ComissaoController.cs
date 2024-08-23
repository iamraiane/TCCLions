using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Commands.ComissaoCommands.CreateComissaoCommand;
using TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand;
using TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand;
using TCCLions.API.Application.Models.Requests.Comissao;
using TCCLions.API.Application.Models.Requests.Comissao.Filters;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Models.ViewModels.Extensions;
using TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;

namespace TCCLions.API.Controllers;

[Route("api/v1/comissao")]
[ApiController]
public class ComissaoController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [ProducesResponseType(typeof(List<ComissaoViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll([FromQuery] ComissaoFilterRequest filter)
    {
        var data = await _mediator.Send(new GetAllComissaoQuery { NomeDoMembro = filter.NomeDoMembro, TipoComissao = filter.TipoComissao });

        if (!data.Any())
            return NoContent();

        var result = data.Select(value => value.ToViewModel());

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateComissaoRequest request)
    {
        var isCreated = await _mediator.Send(new CreateComissaoCommand { TipoComissaoId = request.TipoComissaoId, MembroId = request.MembroId });

        if (isCreated is null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { id = isCreated }, isCreated);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ComissaoViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var data = await _mediator.Send(new GetComissaoQuery { Id = id });

        if (data is null)
            return NotFound();

        return Ok(data.ToViewModel());
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateComissaoRequest request)
    {
        var isUpdated = await _mediator.Send(new UpdateComissaoCommand { Id = id, TipoComissaoId = request.TipoComissaoId });

        if (isUpdated is false)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isDeleted = await _mediator.Send(new DeleteComissaoCommand { Id = id });

        if (isDeleted is false)
            return BadRequest();

        return Ok();
    }

}
