using TccLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.DTOs;

public class DespesaDTO
{
    public Guid Id { get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
    public TipoDeDespesaDTO TipoDeDespesa { get; set; }
}