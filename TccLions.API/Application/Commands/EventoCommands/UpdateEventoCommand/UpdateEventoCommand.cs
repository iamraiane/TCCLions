using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.EventoCommands.UpdateEventoCommand
{
    public class UpdateEventoCommand : IRequest<bool>
    {
        public Guid Id {get; set;}
        public string NomeEvento {get; set;}
        public int QuantidadeVenda {get; set;}
        public DateTime DataVenda {get; set;}
        public double ValorTotal {get; set;}
    }
}