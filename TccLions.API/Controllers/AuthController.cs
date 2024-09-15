using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Commands.AuthCommands.AddRoleCommand;
using TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;
using TCCLions.API.Application.Models.Requests.Auth;
using TCCLions.API.Application.Models.ViewModels;
using TCCLions.API.Application.Queries.AuthQueries.LoginQuery;
using TCCLions.API.Application.Security;

namespace TCCLions.API.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost("register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var operationResult = await _mediator.Send(new CreateMembroCommand
        { 
            Cpf = request.Cpf,
            Email = request.Email,
            EstadoCivilId = request.EstadoCivilId,
            Nome = request.Nome,
            Senha = request.Senha
        });

        if (operationResult is null)
            return BadRequest();

        return Ok();
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await _mediator.Send(new LoginQuery
        {
            NomeOuEmail = request.NomeOuEmail,
            Senha = request.Senha
        });

        var result = new LoginResponseViewModel
        {
            Token = response.Token
        };

        return Ok(result);
    }

    [HttpPost("{memberId}/add-role")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
    public async Task<IActionResult> AddRole(Guid memberId, [FromBody] string roleName)
    {
        var token = await _mediator.Send(new AddRoleCommand
        {
            MembroId = memberId,
            NomePermissao = roleName
        });

        if (!token)
            return BadRequest();

        return Ok();
    }
}
