using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.DeleteTipoComissaoCommand;

public class DeleteTipoComissaoHandler : IRequestHandler<DeleteTipoComissaoCommand, bool>
{
    private readonly IRepositoryBase<TipoComissao, Guid> _tipoComissaoRepository;
    public DeleteTipoComissaoHandler(IRepositoryBase<TipoComissao, Guid> tipoComissaoRepository)
    {
        _tipoComissaoRepository = tipoComissaoRepository;
    }
    public async Task<bool> Handle(DeleteTipoComissaoCommand request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(request);

        var tipoComissao = _tipoComissaoRepository.Get(request.Id);

        _tipoComissaoRepository.Remove(tipoComissao);

        return await _tipoComissaoRepository.SaveChangesAsync();
    }
}