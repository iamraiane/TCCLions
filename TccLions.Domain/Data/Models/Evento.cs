using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Core;

namespace TccLions.Domain.Data.Models
{
    public class Evento : Entity<Guid>
    {
        public Evento(string nomeEvento, int quantidadeVenda, DateTime dataVenda, double valorTotal)
        {
            Id = Guid.NewGuid();
            NomeEvento = nomeEvento;
            QuantidadeVenda = quantidadeVenda;
            DataVenda = dataVenda;
            ValorTotal = valorTotal;            
        }
        public string NomeEvento {get; private set;}
        public int QuantidadeVenda {get; private set;}
        public DateTime DataVenda {get; private set;}
        public double ValorTotal {get; private set;}
        public void Update(string nomeEvento, int quantidadeVenda, DateTime dataVenda, double valorTotal){
            NomeEvento = nomeEvento;
            QuantidadeVenda = quantidadeVenda;
            DataVenda = dataVenda;
            ValorTotal = valorTotal;
        }
    }
}