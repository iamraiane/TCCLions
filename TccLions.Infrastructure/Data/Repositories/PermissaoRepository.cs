using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class PermissaoRepository(ApplicationDataContext context) : RepositoryBase<Permissao, Guid>(context), IPermissaoRepository
{
    public Permissao GetByName(string name)
    {
        return _entity.FirstOrDefault(x => x.Nome == name);
    }
}
