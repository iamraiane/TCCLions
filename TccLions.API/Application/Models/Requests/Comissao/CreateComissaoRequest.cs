namespace TCCLions.API.Application.Models.Requests.Comissao;

public class CreateComissaoRequest
{
    public Guid TipoComissaoId { get; set; }
    public Guid MembroId { get; set; }
}
