using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand
{
    public class DeleteMembroCommand : IRequest<bool>
    {
        public Guid Id {get; set;}
    }
}