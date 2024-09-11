using MediatR;
using TccLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.TipoComissaoQueries.GetAllTipoComissaoQuery;

public class GetAllTipoComissaoQueryHandler(IRepositoryBase<TipoComissao, Guid> repository) : IRequestHandler<GetAllTipoComissaoQuery, IEnumerable<TipoComissaoDTO>>
{
    private readonly IRepositoryBase<TipoComissao, Guid> _repository = repository;

    public Task<IEnumerable<TipoComissaoDTO>> Handle(GetAllTipoComissaoQuery request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(nameof(request));

        var data = _repository.GetAll()
        .Select(x => new TipoComissaoDTO{
            Id = x.Id,
            Descricao = x.Descricao
        });

        return Task.FromResult(data);
    }
}