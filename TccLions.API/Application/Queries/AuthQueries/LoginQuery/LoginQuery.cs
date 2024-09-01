﻿using MediatR;

namespace TCCLions.API.Application.Queries.AuthQueries.LoginQuery;

public class LoginQuery : IRequest<string>
{
    public string Nome { get; set; }
    public string Senha { get; set; }
}