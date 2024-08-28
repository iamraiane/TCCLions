using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class TipoComissao : Entity<Guid>
{
    public TipoComissao(string descricao)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
    }

    public string Descricao { get; private set; }

    public void Update(string descricao){
        Descricao = descricao;
    }
}
