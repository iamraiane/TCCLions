using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;

namespace TCCLions.API.Application.Commands.DespesaCommands.CreateDespesa;

public class CreateDespesaCommandHandler(IDespesaRepository despesaRepository) : IRequestHandler<CreateDespesaCommand, bool>
{
    private readonly IDespesaRepository _repository = despesaRepository ?? throw new ArgumentNullException(nameof(despesaRepository));
    public async Task<bool> Handle(CreateDespesaCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var despesa = new Despesa(request.MembroId, request.TipoDeDespesaId, request.DataVencimento, request.DataRegistro, request.ValorTotal);

        _repository.Create(despesa);

        return await _repository.SaveChangesAsync();
    }
}
