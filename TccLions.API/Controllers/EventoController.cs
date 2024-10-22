using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLions.API.Application.Commands.EventoCommands.CreateEventoCommand;
using TccLions.API.Application.Commands.EventoCommands.DeleteEventoCommand;
using TccLions.API.Application.Commands.EventoCommands.UpdateEventoCommand;
using TccLions.API.Application.Models.Requests.Evento;
using TccLions.API.Application.Models.ViewModels;
using TccLions.API.Application.Models.ViewModels.Extensions;
using TccLions.API.Application.Queries.EventoQueries.GetAllEventoQuery;
using TccLions.API.Application.Queries.EventoQueries.GetEventoQuery;
using TCCLions.API.Application.Security;

namespace TccLions.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
    public class EventoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    
        [HttpGet]
        [ProducesResponseType(typeof(List<EventoViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAll(){
            var data = await _mediator.Send(new GetAllEventoQuery{});

            if(!data.Any())
                return NoContent();
            
            var result = data.Select( value => value.ToViewModel());

            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventoViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Get(Guid id){
            var data = await _mediator.Send(new GetEventoByIdQuery { Id = id});

            if(data == null)
                return NotFound();

            return Ok(data.ToViewModel());
        }
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateEventoRequest request){
            var result = await _mediator.Send(new CreateEventoCommand{
                NomeEvento = request.NomeEvento,
                QuantidadeVenda = request.QuantidadeVenda,
                DataVenda = request.DataVenda,
                ValorTotal = request.ValorTotal
            });

            if(result == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new {id = result}, result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Delete(Guid id){
            
            var isDeleted = await _mediator.Send(new DeleteEventoCommand { Id = id});

            if(isDeleted == false)
                return BadRequest();

            return Ok();

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventoRequest request)
        {
            var isUpdated = await _mediator.Send(new UpdateEventoCommand{
                Id = id,
                NomeEvento = request.NomeEvento,
                QuantidadeVenda = request.QuantidadeVenda,
                DataVenda = request.DataVenda,
                ValorTotal = request.ValorTotal
            });


            if(isUpdated == false)
                return BadRequest();

            return Ok();

        }

    }
}