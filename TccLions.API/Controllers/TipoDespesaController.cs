using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLions.API.Application.Models.ViewModels;
using TccLions.API.Application.Models.ViewModels.Extensions;
using TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery;
using TCCLions.API.Application.Security;

namespace TccLions.API.Controllers
{
    [ApiController]
    [Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
    [Route("api/v1/tipoDespesa")]
    public class TipoDespesaController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [HttpGet]
        [ProducesResponseType(typeof(List<TipoDespesaViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAll(){
            var data = await _mediator.Send(new GetAllTipoDespesaQuery { });

            if(!data.Any())
                return NoContent();

            var result = data.Select(value => value.ToViewModel());

            return Ok(result);
        }
    }
}