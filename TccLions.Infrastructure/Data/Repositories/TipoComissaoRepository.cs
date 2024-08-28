
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class TipoComissaoRepository : RepositoryBase<TipoComissao, Guid>, ITipoComissaoRepository
    {
        public TipoComissaoRepository(ApplicationDataContext context) : base(context)
        {
        }

        public List<TipoComissao> GetAll()
        {
            return _entity.ToList();
        }
    }
}
