using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.EventoQueries.GetAllEventoQuery
{
    public class GetAllEventoQueryHandler(IEventoRepository repository) : IRequestHandler<GetAllEventoQuery ,IEnumerable<EventoDTO>>
    {
        private readonly IEventoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            public Task<IEnumerable<EventoDTO>> Handle(GetAllEventoQuery request, CancellationToken cancellationToken){
                ArgumentNullException.ThrowIfNull(nameof(request));

                var data = _repository.GetAll()
                .Select(x => new EventoDTO{
                    Id = x.Id,
                    NomeEvento = x.NomeEvento,
                    QuantidadeVenda = x.QuantidadeVenda,
                    DataVenda = x.DataVenda,
                    ValorTotal = x.ValorTotal
                });

                return Task.FromResult(data);
            }
    }
}