using TCCLions.Domain.Data.Models;

namespace TCCLions.Domain.Data.Repositories;

public interface IComissaoRepository : IRepositoryBase<Comissao, Guid>
{
    List<Comissao> GetAll();
}
