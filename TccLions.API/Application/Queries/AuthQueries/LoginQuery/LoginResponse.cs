using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.AuthQueries.LoginQuery;

public class LoginResponse
{
    public string Token { get; set; }
    public MembroDTO Membro { get; set; }
}
