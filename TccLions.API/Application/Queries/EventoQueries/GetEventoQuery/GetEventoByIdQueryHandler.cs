using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.EventoQueries.GetEventoQuery
{
    public class GetEventoByIdQueryHandler(IEventoRepository repository) : IRequestHandler<GetEventoByIdQuery, EventoDTO>
    {
        private readonly IEventoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        public Task<EventoDTO> Handle(GetEventoByIdQuery request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var evento = _repository.Get(request.Id);

            if(evento == null)
                return Task.FromResult((EventoDTO)null);

            return Task.FromResult(new EventoDTO{
                Id = evento.Id,
                NomeEvento = evento.NomeEvento,
                QuantidadeVenda = evento.QuantidadeVenda,
                DataVenda = evento.DataVenda,
                ValorTotal = evento.ValorTotal
            });
        }        
    }
}