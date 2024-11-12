using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.DespesasQueries.GetAllDespesas;

public class GetAllDespesasQueryHandler(IMembroRepository repository) : IRequestHandler<GetAllDespesasQuery, IEnumerable<MembroDTO>>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<IEnumerable<MembroDTO>> Handle(GetAllDespesasQuery request, CancellationToken cancellationToken)
    {
        var data = _repository.GetAllMembroDespesas().Where(m => m.Despesas.Count != 0).Select(_ => new MembroDTO
        {
           Cpf = _.Cpf,
           Enderecos = [],
           EstadoCivil = _.EstadoCivil.ToString(),
           Id = _.Id,
           IsActive = _.IsActive,
           Permissoes = [],
           Quantidade = 0,
           Email = _.Email,
           Nome = _.Nome,
           Despesas = _.Despesas.Select(d => new DespesaDTO
           {
               DataRegistro = d.DataRegistro,
               DataVencimento = d.DataVencimento,
               Id = d.Id,
               TipoDeDespesa = new TipoDeDespesaDTO 
               { 
                    Descricao = d.TipoDeDespesa.Descricao,
                    Id = d.TipoDeDespesa.Id
               },
               ValorTotal = d.ValorTotal
           }).ToList()
        });

        return Task.FromResult(data.AsEnumerable());
    }
}
