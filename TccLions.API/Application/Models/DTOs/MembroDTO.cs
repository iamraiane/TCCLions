namespace TCCLions.API.Application.Models.DTOs;

public class MembroDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public string Email { get; set; }
    public string EstadoCivil { get; set; }
    public string Cpf { get; set; }
    public bool IsActive { get; set; }
    public int Quantidade { get; set; }
}
