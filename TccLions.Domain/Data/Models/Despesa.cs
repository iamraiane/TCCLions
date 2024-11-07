using TccLions.Domain.Data.Models;
using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Despesa : Entity<Guid>
{
    private Despesa()
    {
        Id = Guid.NewGuid();
    }

    public Despesa(Guid membroId, Guid tipoDeDespesaId, DateOnly dataVencimento, DateOnly dataRegistro, double valorTotal) : this()
    {
        _membroId = membroId;
        _tipoDeDespesaId = tipoDeDespesaId;
        DataVencimento = dataVencimento;
        DataRegistro = dataRegistro;
        ValorTotal = valorTotal;
    }

    private Guid _membroId;
    private Guid _tipoDeDespesaId;
    public DateOnly DataVencimento { get; private set; }
    public DateOnly DataRegistro { get; private set; }
    public double ValorTotal { get; private set; }
    public TipoDespesa TipoDeDespesa { get; private set; }
    public Membro Membro { get; private set; }

}
