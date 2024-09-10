using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.DespesasQueries.GetAllDespesas;

public class GetAllDespesasQueryHandler(IDespesaRepository repository) : IRequestHandler<GetAllDespesasQuery, IEnumerable<DespesaDTO>>
{
    private readonly IDespesaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<IEnumerable<DespesaDTO>> Handle(GetAllDespesasQuery request, CancellationToken cancellationToken)
    {
        var data = _repository.GetAll().Select(_ => new DespesaDTO
        {
            DataRegistro = _.DataRegistro,
            DataVencimento = _.DataVencimento,
            NomeDoMembro = _.Membro.Nome,
            ValorTotal = _.ValorTotal
        });

        return Task.FromResult(data);
    }
}
