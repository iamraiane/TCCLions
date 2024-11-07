using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.DespesasQueries.GetMembroDespesasById;

public class GetMembroDespesasByIdQueryHandler(IMembroRepository repository) : IRequestHandler<GetMembroDespesasByIdQuery, MembroDTO>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<MembroDTO> Handle(GetMembroDespesasByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var membro = _repository.GetMembroDespesasById(request.MembroId);

        if (membro is null)
            return null;

        var result = new MembroDTO
        {
            Cpf = membro.Cpf,
            Enderecos = [],
            EstadoCivil = membro.EstadoCivil.ToString(),
            Id = membro.Id,
            IsActive = membro.IsActive,
            Permissoes = [],
            Quantidade = 0,
            Email = membro.Email,
            Nome = membro.Nome,
            Despesas = membro.Despesas.Select(d => new DespesaDTO
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
        };

        return Task.FromResult(result);
    }
}
