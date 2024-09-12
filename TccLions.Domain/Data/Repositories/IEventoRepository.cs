using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.Domain.Data.Repositories
{
    public interface IEventoRepository : IRepositoryBase<Evento, Guid>
    {
       List<Evento> GetAll(); 
    }
}