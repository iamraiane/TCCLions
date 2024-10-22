using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.EventoCommands.DeleteEventoCommand
{
    public class DeleteEventoCommandHandlerValidation : AbstractValidator<DeleteEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        public DeleteEventoCommandHandlerValidation(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository ?? throw new ArgumentNullException(nameof(eventoRepository));
        
            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistEvento)
            .WithMessage("O Evento deve existir no banco de dados.");
        }
        private bool ToExistEvento(Guid eventoId){
            var result = _eventoRepository.Get(eventoId);

            if(result == null)
                return false;

            return true;
        }
    }
}