using MediatR;
using TccLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Queries.TipoComissaoQueries.GetAllTipoComissaoQuery
{
    public class GetAllTipoComissaoQueryHandler(ITipoComissaoRepository repository) : IRequestHandler<GetAllTipoComissaoQuery, IEnumerable<TipoComissaoDTO>>
    {
        private readonly ITipoComissaoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

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