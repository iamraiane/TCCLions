using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Models.ViewModels.Extensions;
using TCCLions.API.Application.Queries.AtasQueries.GetAllAtas;
using TCCLions.API.Application.Queries.AtasQueries.GetAtaById;

namespace TCCLions.API.Controllers;

[Route("api/ata")]
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
}
