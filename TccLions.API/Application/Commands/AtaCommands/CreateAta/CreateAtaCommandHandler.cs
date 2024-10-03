using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.AtaCommands.CreateAta;

public class CreateAtaCommandHandler(IAtaRepository repository) : IRequestHandler<CreateAtaCommand, bool>
{
    private readonly IAtaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<bool> Handle(CreateAtaCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var ata = new Ata(request.Titulo, request.DataEscrita, request.Descricao);

        _repository.Create(ata);

        return await _repository.SaveChangesAsync();
    }
}
