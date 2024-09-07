using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class MembroRepository(ApplicationDataContext context) : RepositoryBase<Membro, Guid>(context), IMembroRepository
{
    public List<Membro> GetAll()
    {
        return _entity.ToList();
    }

    public override Membro Get(Guid id)
    {
        return _entity.Include(x => x.Permissoes).FirstOrDefault(x => x.Id == id);
    }

    public Membro GetByName(string name)
    {
        return _entity.Include(x => x.Permissoes).FirstOrDefault(x => x.Nome == name);
    }
}
