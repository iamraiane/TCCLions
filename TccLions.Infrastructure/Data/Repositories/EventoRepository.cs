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
    public class EventoRepository(ApplicationDataContext context) : RepositoryBase<Evento, Guid>(context), IEventoRepository
    {
        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}