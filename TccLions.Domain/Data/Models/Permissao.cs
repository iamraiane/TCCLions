using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Permissao : Entity<Guid>
{
    public Permissao(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public string Nome { get; private set; }
}
