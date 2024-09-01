﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCLions.API.Application.Commands.AuthCommands.AddRoleCommand;
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
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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