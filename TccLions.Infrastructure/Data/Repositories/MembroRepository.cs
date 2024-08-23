using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class MembroRepository(ApplicationDataContext context) : RepositoryBase<Membro, Guid>(context), IMembroRepository
{
    public List<Membro> GetAll()
    {
        return _entity.ToList();
    }
}
