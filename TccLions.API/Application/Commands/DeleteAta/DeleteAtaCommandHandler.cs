using MediatR;
using TCCLions.Domain.Data.Exceptions;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.DeleteAta;

public class DeleteAtaCommandHandler(IAtaRepository repository) : IRequestHandler<DeleteAtaCommand, bool>
{
    private readonly IAtaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public async Task<bool> Handle(DeleteAtaCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var ata = _repository.Get(request.Id);

        if (ata is null)
            throw new TCCLionsDomainException("Ata não encontrada");

        _repository.Remove(ata);
        
        return await _repository.SaveChangesAsync();
    }
}
