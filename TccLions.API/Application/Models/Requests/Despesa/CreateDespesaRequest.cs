namespace TCCLions.API.Application.Models.Requests.Despesa;

public class CreateDespesaRequest
{
    public Guid MembroId { get; set; }
    public Guid TipoDeDespesaId { get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
}
