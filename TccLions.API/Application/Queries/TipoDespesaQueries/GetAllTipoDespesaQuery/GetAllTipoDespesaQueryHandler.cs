using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using TccLions.Domain.Data.Repositories;
using TCCLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery;

public class GetAllTipoDespesaQueryHandler(ITipoDespesaRepository repository) : IRequestHandler<GetAllTipoDespesaQuery, IEnumerable<TipoDeDespesaDTO>>
{
    private readonly ITipoDespesaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    
    public Task<IEnumerable<TipoDeDespesaDTO>> Handle(GetAllTipoDespesaQuery request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(nameof(request));

        var data = _repository.GetAll()
        .Select(x => new TipoDeDespesaDTO{
            Id = x.Id,
            Descricao = x.Descricao
        });
    
        return Task.FromResult(data);
    }

}