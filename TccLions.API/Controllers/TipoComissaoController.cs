using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand;
using TccLions.API.Application.Commands.TipoComissaoCommands.CreateTipoComissaoCommand;
using TccLions.API.Application.Commands.TipoComissaoCommands.DeleteTipoComissaoCommand;
using TccLions.API.Application.Commands.TipoComissaoCommands.UpdateTipoComissaoCommand;
using TccLions.API.Application.Models.Requests.TipoComissao;
using TccLions.API.Application.Models.ViewModels;
using TccLions.API.Application.Models.ViewModels.Extensions;
using TccLions.API.Application.Queries.TipoComissaoQueries.GetAllTipoComissaoQuery;
using TccLions.API.Application.Queries.TipoComissaoQueries.GetTipoComissaoQuery;
using TCCLions.API.Application.Security;

namespace TccLions.API.Controllers
{
    [ApiController]
    [Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
    [Route("api/v1/tipoComissao")]
    public class TipoComissaoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        [ProducesResponseType(typeof(List<TipoComissaoViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllTipoComissaoQuery { });

            if (!data.Any())
                return NoContent();

            var result = data.Select(value => value.ToViewModel());

            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateTipoComissaoRequest request)
        {
            var result = await _mediator.Send(new CreateTipoComissaoCommand
            {
                Descricao = request.Descricao
            });

            if (result is null)
                return BadRequest();

            return CreatedAtAction(nameof(GetAll), new { id = result }, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TipoComissaoViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetTipoComissaoByIdQuery { Id = id });

            if (result is null)
                return NotFound();

            return Ok(result.ToViewModel());
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTipoComissaoRequest request)
        {
            var isUpdated = await _mediator.Send(new UpdateTipoComissaoCommand
            {
                Id = id,
                Descricao = request.Descricao
            });

            if (!isUpdated.Value)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _mediator.Send(new DeleteTipoComissaoCommand { Id = id });

            if (!isDeleted)
                return BadRequest();

            return Ok();
        }
    }
}