using TCCLions.Domain.Data.Models;

namespace TCCLions.Domain.Data.Repositories;

public interface ITipoComissaoRepository : IRepositoryBase<TipoComissao, Guid>
{
    List<TipoComissao> GetAll();
}
