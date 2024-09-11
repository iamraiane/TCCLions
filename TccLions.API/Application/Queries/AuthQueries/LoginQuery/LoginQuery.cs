using MediatR;

namespace TCCLions.API.Application.Queries.AuthQueries.LoginQuery;

public class LoginQuery : IRequest<LoginResponse>
{
    public string NomeOuEmail { get; set; }
    public string Senha { get; set; }
}
