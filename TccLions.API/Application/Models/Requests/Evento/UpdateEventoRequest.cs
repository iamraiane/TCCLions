using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccLions.API.Application.Models.Requests.Evento
{
    public class UpdateEventoRequest
    {
        public string NomeEvento {get; set;}
        public int QuantidadeVenda {get; set;}
        public DateTime DataVenda {get; set;}
        public double ValorTotal {get; set;}
    }
}