using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.EventoCommands.DeleteEventoCommand
{
    public class DeleteEventoCommandHandler : IRequestHandler<DeleteEventoCommand, bool>
    {
        private readonly IEventoRepository _eventoRepository;
        public DeleteEventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        public async Task<bool> Handle(DeleteEventoCommand request, CancellationToken cancellationToken){
            
            ArgumentNullException.ThrowIfNull(request);

            var evento = _eventoRepository.Get(request.Id);

            _eventoRepository.Remove(evento);

            return await _eventoRepository.SaveChangesAsync();
        }

        
    }
}