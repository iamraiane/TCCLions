using MediatR;
using TccLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.TipoComissaoQueries.GetTipoComissaoQuery;

public class GetTipoComissaoByIdQueryHandler(IRepositoryBase<TipoComissao, Guid> repository) : IRequestHandler<GetTipoComissaoByIdQuery, TipoComissaoDTO>
{
    private readonly IRepositoryBase<TipoComissao, Guid> _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public Task<TipoComissaoDTO> Handle(GetTipoComissaoByIdQuery request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(request);

        var tipoComissao = _repository.Get(request.Id);

        if(tipoComissao == null)
            return Task.FromResult((TipoComissaoDTO)null);
        
        return Task.FromResult( new TipoComissaoDTO{
            Id = tipoComissao.Id,
            Descricao  = tipoComissao.Descricao
        });

    }
}

