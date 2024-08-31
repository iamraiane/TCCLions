using MediatR;
using TCCLions.Domain.Data.Exceptions;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.AuthCommands.SetAdminCommand;

public class AddRoleCommandHandler(IMembroRepository membroRepository, IPermissaoRepository permissaoRepository) : IRequestHandler<AddRoleCommand, bool>
{
    private readonly IMembroRepository _membroRepository = membroRepository ?? throw new ArgumentNullException(nameof(membroRepository));
    private readonly IPermissaoRepository _permissaoRepository = permissaoRepository ?? throw new ArgumentNullException(nameof(permissaoRepository));

    public Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var membro = _membroRepository.Get(request.MembroId);

        if (membro is null)
            throw new MembroDomainException("Membro não encontrado.");

        var permissao = _permissaoRepository.GetByName(request.NomePermissao) ?? throw new TCCLionsDomainException("Permissão não encontrada.");

        if (membro.Permissoes.Any(x => x.Nome == permissao.Nome))
            throw new MembroDomainException("Membro já tem essa permissão.");

        membro.AddPermission(permissao);

        return _membroRepository.SaveChangesAsync();
    }
}
