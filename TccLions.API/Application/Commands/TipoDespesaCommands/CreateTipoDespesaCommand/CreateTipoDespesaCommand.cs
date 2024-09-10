using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.CreateTipoDespesaCommand
{
    public class CreateTipoDespesaCommand : IRequest<Guid?>
    {
        public string Descricao {get; set;}
    }
}