using MediatR;
using TCCLions.Domain.Data.Exceptions;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.MembroCommands.DisableMembro;

public class DisableMembroCommandHandler(IMembroRepository repository) : IRequestHandler<DisableMembroCommand, bool>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<bool> Handle(DisableMembroCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var membro = _repository.Get(request.Id);

        if (membro is null)
            throw new MembroDomainException("O membro não existe no banco de dados");

        membro.Disable();
        _repository.Update(membro);

        return _repository.SaveChangesAsync();
    }
}
