using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TccLions.API.Application.Models.ViewModels;
using TccLions.API.Application.Models.ViewModels.Extensions;
using TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery;
using TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;

namespace TccLions.API.Controllers
{
    [ApiController]
    [Route("api/v1/tipoDespesa")]
    public class TipoDespesaController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [HttpGet]
        [ProducesResponseType(typeof(List<TipoDespesaViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll(){
            var data = await _mediator.Send(new GetAllTipoDespesaQuery { });

            if(!data.Any())
                return NoContent();

            var result = data.Select(value => value.ToViewModel());

            return Ok(result);
        }
    }
}