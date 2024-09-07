using TccLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.Domain.Data.Repositories;

public interface ITipoDespesaRepository : IRepositoryBase<TipoDespesa, Guid>
{
    List<TipoDespesa> GetAll();
}