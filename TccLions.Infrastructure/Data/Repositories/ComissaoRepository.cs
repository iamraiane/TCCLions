using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class ComissaoRepository : RepositoryBase<Comissao, Guid>, IComissaoRepository
{
    public ComissaoRepository(ApplicationDataContext context) : base(context)
    {
    }

    public List<Comissao> GetAll()
    {
        return _entity.Include(x => x.TipoComissao)
            .Include(x => x.Membro)
            .ToList();
    }

    public override Comissao Get(Guid key)
    {
        return _entity.Include(x => x.TipoComissao).FirstOrDefault(x => x.Id == key);
    }
}
