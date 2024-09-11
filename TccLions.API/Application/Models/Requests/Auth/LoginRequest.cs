namespace TCCLions.API.Application.Models.Requests.Auth;

public class LoginRequest
{
    public string NomeOuEmail { get; set; }
    public string Senha { get; set; }
}
