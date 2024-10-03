using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Commands.AtaCommands.CreateAta;
using TCCLions.API.Application.Commands.AtaCommands.UpdateAta;
using TCCLions.API.Application.Commands.DeleteAta;
using TCCLions.API.Application.Models.Requests.Ata;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Models.ViewModels.Extensions;
using TCCLions.API.Application.Queries.AtasQueries.GetAllAtas;
using TCCLions.API.Application.Queries.AtasQueries.GetAtaById;

namespace TCCLions.API.Controllers;

[Route("api/v1/ata")]
[Authorize]
[ApiController]
public class AtasController : ControllerBase
{
    private readonly IMediator _mediator;

    public AtasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemsViewModel<AtaViewModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var data = await _mediator.Send(new GetAllAtasQuery());

        if (!data.Any())
            return Ok(new PaginatedItemsViewModel<AtaViewModel>
            {
                Dados = [],
                IndiceDaPagina = 0,
                Quantidade = 0,
                TamanhoDaPagina = 0
            });

        var paginated = new PaginatedItemsViewModel<AtaViewModel>
        {
            Dados = data.Select(_ => _.ToViewModel()),
            IndiceDaPagina = 0,
            Quantidade = 0,
            TamanhoDaPagina = 0
        };

        return Ok(paginated);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AtaViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var data = await _mediator.Send(new GetAtaByIdQuery { Id = id });

        if (data is null)
            return NotFound();

        return Ok(data.ToViewModel());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateAtaRequest request)
    {
        var operationResult = await _mediator.Send(new CreateAtaCommand
        {
            DataEscrita = request.DataEscrita,
            Descricao = request.Descricao,
            Titulo = request.Titulo
        });

        if (!operationResult)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var operationResult = await _mediator.Send(new DeleteAtaCommand
        {
            Id = id
        });

        if (!operationResult)
            return BadRequest();

        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAtaRequest request)
    {
        var operationResult = await _mediator.Send(new UpdateAtaCommand
        {
            Id = id,
            DataEscrita = request.DataEscrita,
            Descricao = request.Descricao,
            Titulo = request.Titulo
        });

        if (operationResult is null)
            return NotFound();
        
        if (!operationResult.Value) 
            return BadRequest();

        return Ok();
    }
}
