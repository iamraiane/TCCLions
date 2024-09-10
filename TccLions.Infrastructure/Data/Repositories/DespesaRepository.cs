using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class DespesaRepository : RepositoryBase<Despesa, Guid>, IDespesaRepository
{
    public DespesaRepository(ApplicationDataContext context) : base(context)
    {
        
    }
}
