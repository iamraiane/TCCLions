using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.UpdateTipoDespesaCommand
{
    public class UpdateTipoDespesaCommand : IRequest<bool?>
    {
        public Guid Id {get; set;}
        public string Descricao {get; set;}
    }
}