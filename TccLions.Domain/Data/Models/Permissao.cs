using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Permissao : Entity<Guid>
{
    private List<Membro> _membros = [];

    public Permissao(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public string Nome { get; private set; }
    public IReadOnlyCollection<Membro> Membros => _membros;
}
