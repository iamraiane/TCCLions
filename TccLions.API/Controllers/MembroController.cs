using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TccLions.API.Application.Commands.MembroCommands.UpdateMembroCommands;
using TccLions.API.Application.Models.Requests.Membro;
using TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;
using TCCLions.API.Application.Models.Requests.Membro;
using TCCLions.API.Application.Models.Requests.Membro.Filters;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Models.ViewModels.Extensions;
using TCCLions.API.Application.Queries.MembroQueries.GetAllMembrosQuery;
using TCCLions.API.Application.Queries.MembroQueries.GetMembroQuery;
using TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand;
using TCCLions.API.Application.Commands.MembroCommands.DisableMembro;

namespace TCCLions.API.Controllers;

[Route("api/v1/membro")]
[ApiController]
public class MembroController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemsViewModel<MembroViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll([FromQuery] MembroFilterRequest filter)
    {
        var data = await _mediator.Send(new GetAllMembrosQuery 
        {
            NomeDoMembro = filter.NomeDoMembro,
            MostrarDesabilitados = filter.MostrarDesabilitados,
            TamanhoDaPagina = filter.TamanhoDaPagina,
            IndiceDaPagina = filter.IndiceDaPagina
        });

        if (!data.Any())
            return NoContent();

        var paginated = new PaginatedItemsViewModel<MembroViewModel>
        {
            IndiceDaPagina = filter.IndiceDaPagina,
            TamanhoDaPagina = filter.TamanhoDaPagina,
            Quantidade = data.FirstOrDefault().Quantidade,
            Dados = data.Select(_ => _.ToViewModel())
        };

        return Ok(paginated);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateMembroRequest request)
    {
        var result = await _mediator.Send(new CreateMembroCommand
        {
            Bairro = request.Bairro,
            Cep = request.Cep,
            Cidade = request.Cidade,
            Cpf = request.Cpf,
            Email = request.Email,
            Endereco = request.Endereco,
            EstadoCivilId = request.EstadoCivilId,
            Nome = request.Nome
        });

        if (result is null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MembroViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetMembroByIdQuery { Id = id });

        if (result is null)
            return NotFound();

        return Ok(result.ToViewModel());
    }
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMembroRequest request)
    {
        var isUpdated = await _mediator.Send(new UpdateMembroCommand
        {
            Id = id,
            Nome = request.Nome,
            Endereco = request.Endereco,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Cep = request.Cep,
            Email = request.Email,
            EstadoCivilId = request.EstadoCivilId,
            Cpf = request.Cpf
        });

        if (isUpdated == false)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(Guid id)
    {

        var isDeleted = await _mediator.Send(new DeleteMembroCommand { Id = id });

        if (isDeleted == false)
            return BadRequest();

        return Ok();
    }

    [HttpPost("{id}/disable")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Disable(Guid id)
    {
        var result = await _mediator.Send(new DisableMembroCommand { Id = id });

        if (!result)
            return BadRequest();

        return Ok();
    }

    [HttpPost("{id}/enable")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Enable(Guid id)
    {
        var result = await _mediator.Send(new EnableMembroCommand { Id = id });

        if (!result)
            return BadRequest();

        return Ok();
    }
}
