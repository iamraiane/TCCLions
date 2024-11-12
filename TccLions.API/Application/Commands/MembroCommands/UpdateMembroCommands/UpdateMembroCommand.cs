using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TccLions.API.Application.Commands.MembroCommands.UpdateMembroCommands
{
    public class UpdateMembroCommand : IRequest<bool?>
    {
        public Guid Id {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public int EstadoCivilId { get; set; }
        public string Cpf { get; set; }
    }
}