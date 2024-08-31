using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCLions.API.Application.Commands.AuthCommands.SetAdminCommand;
using TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;
using TCCLions.API.Application.Models.Requests.Auth;
using TCCLions.API.Application.Queries.AuthQueries.LoginQuery;
using TCCLions.API.Application.Security;

namespace TCCLions.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var operationResult = await _mediator.Send(new CreateMembroCommand
        { 
            Bairro = request.Bairro,
            Cep = request.Cep,
            Cidade = request.Cidade,
            Cpf = request.Cpf,
            Email = request.Email,
            Endereco = request.Endereco,
            EstadoCivilId = request.EstadoCivilId,
            Nome = request.Nome,
            Senha = request.Senha
        });

        if (operationResult is null)
            return BadRequest();

        return Ok();
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _mediator.Send(new LoginQuery
        {
            Nome = request.Nome,
            Senha = request.Senha
        });

        return Ok(token);
    }

    [HttpPost("{memberId}/add-role")]
    [Authorize(Policy = SecurityInfo.Policies.AdminOnly)]
    public async Task<IActionResult> SetAdmin(Guid memberId, [FromBody] string roleName)
    {
        var token = await _mediator.Send(new AddRoleCommand
        {
            MembroId = memberId,
            NomePermissao = roleName
        });

        return Ok(token);
    }
}
