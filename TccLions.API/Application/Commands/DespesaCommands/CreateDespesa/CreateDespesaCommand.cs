using MediatR;

namespace TCCLions.API.Application.Commands.DespesaCommands.CreateDespesa;

public class CreateDespesaCommand : IRequest<bool>
{
    public Guid MembroId { get; set; }
    public Guid TipoDeDespesaId { get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
}
