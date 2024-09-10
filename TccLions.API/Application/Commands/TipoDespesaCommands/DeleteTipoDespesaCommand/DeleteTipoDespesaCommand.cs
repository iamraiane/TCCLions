using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.DeleteTipoDespesaCommand
{
    public class DeleteTipoDespesaCommand : IRequest<bool>
    {
        public Guid Id {get; set;}
    }
}