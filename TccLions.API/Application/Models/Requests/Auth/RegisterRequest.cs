namespace TCCLions.API.Application.Models.Requests.Auth;

public class RegisterRequest
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public string Email { get; set; }
    public int EstadoCivilId { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
}
