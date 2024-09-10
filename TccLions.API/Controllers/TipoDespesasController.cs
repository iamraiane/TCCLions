using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLions.API.Application.Commands.TipoDespesaCommands.CreateTipoDespesaCommand;
using TccLions.API.Application.Commands.TipoDespesaCommands.DeleteTipoDespesaCommand;
using TccLions.API.Application.Commands.TipoDespesaCommands.UpdateTipoDespesaCommand;
using TccLions.API.Application.Models.Requests.TipoDespesa;
using TccLions.API.Application.Models.ViewModels;
using TccLions.API.Application.Models.ViewModels.Extensions;
using TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery;
using TccLions.API.Application.Queries.TipoDespesaQueries.GetTipoDespesaQuery;
using TCCLions.API.Application.Security;

namespace TccLions.API.Controllers;

[ApiController]
[Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
[Route("api/v1/tipo-despesa")]
public class TipoDespesasController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [ProducesResponseType(typeof(List<TipoDespesaViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> GetAll()
    {
        var data = await _mediator.Send(new GetAllTipoDespesaQuery { });

        if (!data.Any())
            return NoContent();

        var result = data.Select(value => value.ToViewModel());

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> Create([FromBody] CreateTipoDespesaRequest request)
    {
        var result = await _mediator.Send(new CreateTipoDespesaCommand
        {
            Descricao = request.Descricao
        });

        if (result == null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TipoDespesaViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetTipoDespesaByIdQuery { Id = id });

        if (result == null)
            return NotFound();

        return Ok(result.ToViewModel());
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTipoDespesaRequest request)
    {
        var isUpdated = await _mediator.Send(new UpdateTipoDespesaCommand
        {
            Id = id,
            Descricao = request.Descricao
        });

        if (isUpdated == false)
            return BadRequest();

        return Ok();
    }
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isDeleted = await _mediator.Send(new DeleteTipoDespesaCommand { Id = id });

        if (isDeleted == false)
            return BadRequest();

        return Ok();
    }
}