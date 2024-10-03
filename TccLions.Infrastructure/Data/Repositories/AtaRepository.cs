using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class AtaRepository : RepositoryBase<Ata, Guid>, IAtaRepository
{
    public AtaRepository(ApplicationDataContext context) : base(context)
    {
        
    }
}
