using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;
using TccLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetTipoDespesaQuery
{
    public class GetTipoDespesaByQueryHandler(ITipoDespesaRepository repository) : IRequestHandler<GetTipoDespesaByIdQuery, TipoDespesaDTO>
    {
        private readonly ITipoDespesaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    
        public Task<TipoDespesaDTO> Handle(GetTipoDespesaByIdQuery request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoDespesa = _repository.Get(request.Id);

            if(tipoDespesa == null)
                return Task.FromResult((TipoDespesaDTO)null);

            return Task.FromResult( new TipoDespesaDTO{
                Id = tipoDespesa.Id,
                Descricao = tipoDespesa.Descricao
            });
        }
    }
}