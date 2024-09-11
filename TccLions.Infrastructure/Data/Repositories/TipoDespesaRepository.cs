using TccLions.Domain.Data.Models;
using TccLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data;
using TCCLions.Infrastructure.Data.Repositories;

namespace TccLions.Infrastructure.Data.Repositories
{
    public class TipoDespesaRepository : RepositoryBase<TipoDespesa, Guid>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(ApplicationDataContext context) : base(context)
        {

        }
    }
}