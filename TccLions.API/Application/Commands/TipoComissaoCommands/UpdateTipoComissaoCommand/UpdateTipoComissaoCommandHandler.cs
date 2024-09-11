using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.UpdateTipoComissaoCommand;

public class UpdateTipoComissaoCommandHandler : IRequestHandler<UpdateTipoComissaoCommand, bool?>
{
    private IRepositoryBase<TipoComissao, Guid> _tipoComissaoRepository;

    public UpdateTipoComissaoCommandHandler(IRepositoryBase<TipoComissao, Guid> tipoComissaoRepository)
    {
        _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
    }

    public async Task<bool?> Handle(UpdateTipoComissaoCommand request, CancellationToken cancellationToken){
        ArgumentNullException.ThrowIfNull(request);

        var tipoComissao = _tipoComissaoRepository.Get(request.Id);

        tipoComissao.Update(request.Descricao);

        return await _tipoComissaoRepository.SaveChangesAsync();
    }
}