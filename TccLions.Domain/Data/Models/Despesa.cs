using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Despesa : Entity<Guid>
{
    private Despesa()
    {
        Id = Guid.NewGuid();
    }

    public Despesa(Guid membroId, DateOnly dataVencimento, DateOnly dataRegistro, double valorTotal) : this()
    {
        _membroId = membroId;
        DataVencimento = dataVencimento;
        DataRegistro = dataRegistro;
        ValorTotal = valorTotal;
    }

    private Guid _membroId;
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
    public Membro Membro { get; set; }

}
