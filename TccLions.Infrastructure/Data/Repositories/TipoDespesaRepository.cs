using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLions.Domain.Data.Models;
using TccLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data;
using TCCLions.Infrastructure.Data.Repositories;

namespace TccLions.Infrastructure.Data.Repositories
{
    public class TipoDespesaRepository : RepositoryBase<TipoDespesa, Guid>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(ApplicationDataContext context) : base(context){

        }

        public List<TipoDespesa> GetAll()
        {
            return _entity.ToList();
        }
    }
}