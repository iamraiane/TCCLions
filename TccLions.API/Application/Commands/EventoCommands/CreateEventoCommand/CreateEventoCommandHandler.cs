using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.Domain.Data.Models;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.EventoCommands.CreateEventoCommand
{
    public class CreateEventoCommandHandler(IEventoRepository repository) : IRequestHandler<CreateEventoCommand, Guid?>
    {
        private readonly IEventoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<Guid?> Handle(CreateEventoCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var evento = new Evento(request.NomeEvento, request.QuantidadeVenda, 
                    request.DataVenda, request.ValorTotal);

            repository.Create(evento);

            if(!await _repository.SaveChangesAsync())
                return null;

            return evento.Id;
        }
    }
}