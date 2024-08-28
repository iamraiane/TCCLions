using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery
{
    public class GetAllTipoDespesaQueryHandler(ITipoDespesaRepository repository) : IRequestHandler<GetAllTipoDespesaQuery, IEnumerable<TipoDespesaDTO>>
    {
        private readonly ITipoDespesaRepository _repository = repository;
        
        public Task<IEnumerable<TipoDespesaDTO>> Handle(GetAllTipoDespesaQuery request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(nameof(request));

            var data = _repository.GetAll()
            .Select(x => new TipoDespesaDTO{
                Id = x.Id,
                Descricao = x.Descricao
            });
        
            return Task.FromResult(data);
        }

    }
}