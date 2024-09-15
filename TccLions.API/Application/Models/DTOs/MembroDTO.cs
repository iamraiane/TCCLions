namespace TCCLions.API.Application.Models.DTOs;

public class MembroDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string EstadoCivil { get; set; }
    public string Cpf { get; set; }
    public bool IsActive { get; set; }
    public int Quantidade { get; set; }
    public IEnumerable<PermissaoDTO> Permissoes { get; set; }
    public IEnumerable<EnderecoDTO> Enderecos { get; set; }
}
