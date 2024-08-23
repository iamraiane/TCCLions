using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Comissao : Entity<Guid>
{
    public Comissao() { }

    public Comissao(Guid tipoComissaoId, Guid membroId)
    {
        Id = Guid.NewGuid();
        _tipoComissaoId = tipoComissaoId;
        _membroId = membroId;
    }

    private Guid _tipoComissaoId;
    public TipoComissao TipoComissao { get; private set; }

    private Guid _membroId;
    public Membro Membro { get; private set; }

    public void Update(Guid tipoComissaoId)
    {
        _tipoComissaoId = tipoComissaoId;
    }
}
