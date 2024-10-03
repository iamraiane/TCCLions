using MediatR;
using TCCLions.Domain.Data.Exceptions;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.AtaCommands.UpdateAta;

public class UpdateAtaCommandHandler(IAtaRepository repository) : IRequestHandler<UpdateAtaCommand, bool?>
{
    private readonly IAtaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public async Task<bool?> Handle(UpdateAtaCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var ata = _repository.Get(request.Id);

        if (ata is null)
            return null;

        ata.Update(request.Titulo, request.DataEscrita, request.Descricao);

        _repository.Update(ata);

        return await _repository.SaveChangesAsync();
    }
}
