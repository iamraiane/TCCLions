using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.ComissaoQueries.GetComissaoQuery;

public class GetComissaoQueryHandler(IComissaoRepository repository) : IRequestHandler<TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery.GetComissaoQuery, ComissaoDTO>
{
    private readonly IComissaoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<ComissaoDTO> Handle(TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery.GetComissaoQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var data = _repository.Get(request.Id);

        if (data is null)
            return Task.FromResult((ComissaoDTO)null);

        return Task.FromResult(new ComissaoDTO { Id = data.Id, TipoComissao = data.TipoComissao.Descricao});
    }
}
