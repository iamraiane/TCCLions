using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.DespesaCommands.DeleteDespesaById;

public class DeleteDespesaByIdQueryHandler(IDespesaRepository despesaRepository) : IRequestHandler<DeleteDespesaByIdQuery, bool?>
{
    private readonly IDespesaRepository _despesaRepository = despesaRepository ?? throw new ArgumentNullException(nameof(despesaRepository));
    public async Task<bool?> Handle(DeleteDespesaByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var despesa = _despesaRepository.Get(request.Id);

        if (despesa is null)
            return null;

        _despesaRepository.Remove(despesa);

        return await _despesaRepository.SaveChangesAsync();
    }
}
