using TCCLions.Domain.Data.Models;

namespace TCCLions.Domain.Data.Repositories;

public interface IPermissaoRepository : IRepositoryBase<Permissao, Guid>
{
    Permissao GetByName(string name);
}
