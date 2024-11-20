using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Commands.DespesaCommands.CreateDespesa;
using TCCLions.API.Application.Commands.DespesaCommands.DeleteDespesaById;
using TCCLions.API.Application.Models.Requests.Despesa;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Models.ViewModels.Extensions;
using TCCLions.API.Application.Queries.DespesasQueries.GetAllDespesas;
using TCCLions.API.Application.Queries.DespesasQueries.GetMembroDespesasById;

namespace TCCLions.API.Controllers;

[Route("api/v1/[controller]")]
[Authorize]
[ApiController]
public class DespesasController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MembroDespesasViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Get()
    {
        var data = await _mediator.Send(new GetAllDespesasQuery());

        if (!data.Any())
            return NoContent();

        return Ok(data.Select(d => d.ToDespesasViewModel()));
    }

    [HttpGet("{memberId}")]
    [ProducesResponseType(typeof(MembroDespesasViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(Guid memberId)
    {
        var data = await _mediator.Send(new GetMembroDespesasByIdQuery
        {
            MembroId = memberId
        });

        if (data is null)
            return NotFound();

        return Ok(data.ToDespesasViewModel());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post([FromBody] CreateDespesaRequest request)
    {
        var operationResult = await _mediator.Send(new CreateDespesaCommand 
        {
            ValorTotal = request.ValorTotal,
            TipoDeDespesaId = request.TipoDeDespesaId,
            DataRegistro = request.DataRegistro,
            DataVencimento = request.DataVencimento,
            MembroId = request.MembroId
        });

        if (!operationResult)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var operationResult = await _mediator.Send(new DeleteDespesaByIdQuery { Id = id });

        if (operationResult is null)
            return NotFound();

        if (!operationResult.Value)
            return BadRequest();

        return Ok();
    }
}
