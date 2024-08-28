using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.CreateTipoComissaoCommand
{
    public class CreateTipoComissaoCommand : IRequest<Guid?>
    {
        public string Descricao {get; set;}
    }
}