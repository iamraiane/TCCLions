using MediatR;
using TccLions.Domain.Data.Repositories;
using TCCLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetTipoDespesaQuery;

public class GetTipoDespesaByQueryHandler(ITipoDespesaRepository repository) : IRequestHandler<GetTipoDespesaByIdQuery, TipoDeDespesaDTO>
{
    private readonly ITipoDespesaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public Task<TipoDeDespesaDTO> Handle(GetTipoDespesaByIdQuery request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(request);

        var tipoDespesa = _repository.Get(request.Id);

        if(tipoDespesa == null)
            return Task.FromResult((TipoDeDespesaDTO)null);

        return Task.FromResult( new TipoDeDespesaDTO{
            Id = tipoDespesa.Id,
            Descricao = tipoDespesa.Descricao
        });
    }
}