using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;

public class CreateMembroCommandHandler(IMembroRepository repository) : IRequestHandler<CreateMembroCommand, Guid?>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public async Task<Guid?> Handle(CreateMembroCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var membro = new Membro(request.Nome, request.Endereco, request.Bairro, request.Cidade, request.Cep, request.Email, (EstadoCivilEnum)Enum.ToObject(typeof(EstadoCivilEnum), request.EstadoCivilId), request.Cpf);

        _repository.Create(membro);

        if (!await _repository.SaveChangesAsync())
            return null;

        return membro.Id;
    }
}
