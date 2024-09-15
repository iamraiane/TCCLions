using MediatR;
using TCCLions.API.Application.Services;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;

public class CreateMembroCommandHandler(IMembroRepository repository, IPasswordHasher passwordHasher) : IRequestHandler<CreateMembroCommand, Guid?>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IPasswordHasher _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    public async Task<Guid?> Handle(CreateMembroCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var password = _passwordHasher.HashPassword(request.Senha);

        var membro = new Membro
            (
                request.Nome,
                request.Email,
                (EstadoCivilEnum)Enum.ToObject(typeof(EstadoCivilEnum), request.EstadoCivilId),
                request.Cpf,
                password
            );

        _repository.Create(membro);

        if (!await _repository.SaveChangesAsync())
            return null;

        return membro.Id;
    }
}
