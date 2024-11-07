using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Core;

namespace TccLions.Domain.Data.Models
{
    public class TipoDespesa : Entity<Guid>
    {
        public TipoDespesa(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }
        public string Descricao { get; private set; }

        public void Update(string descricao){
            Descricao = descricao;
        }
    }
}