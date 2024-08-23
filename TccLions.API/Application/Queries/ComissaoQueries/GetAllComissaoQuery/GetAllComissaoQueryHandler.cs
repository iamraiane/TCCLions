using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;

public class GetAllComissaoQueryHandler(IComissaoRepository repository) : IRequestHandler<GetAllComissaoQuery, IEnumerable<ComissaoDTO>>
{
    private readonly IComissaoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<IEnumerable<ComissaoDTO>> Handle(GetAllComissaoQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(request));

        var data = _repository.GetAll()
            .Where(x => (request.TipoComissao is null) || x.TipoComissao.Descricao.Contains(request.TipoComissao))
            .Where(x => (request.NomeDoMembro is null) || x.Membro.Nome.Contains(request.NomeDoMembro, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => new ComissaoDTO { Id = x.Id, TipoComissao = x.TipoComissao.Descricao, NomeDoMembro = x.Membro.Nome });

        return Task.FromResult(data);
    }
}
