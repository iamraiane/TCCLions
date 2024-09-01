﻿using MediatR;
using TCCLions.API.Application.Services;
using TCCLions.Domain.Data.Exceptions;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.AuthQueries.LoginQuery;

public class LoginQueryHandler(IMembroRepository repository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, string>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IPasswordHasher _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));

    public Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(request));

        var membro = _repository.GetByName(request.Nome);

        if (membro is null)
            throw new MembroDomainException("Usuário inválido");

        if (!_passwordHasher.VerifyPassword(membro.Senha, request.Senha))
            throw new MembroDomainException("Senha inválida");

        return Task.FromResult(_jwtTokenGenerator.GenerateToken(membro));
    }
}