using FluentValidation;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.DeleteTipoComissaoCommand;

public class DeleteTipoComissaoHandlerValidation : AbstractValidator<DeleteTipoComissaoCommand>
{
    private readonly IRepositoryBase<TipoComissao, Guid> _tipoComissaoRepository;
    public DeleteTipoComissaoHandlerValidation(IRepositoryBase<TipoComissao, Guid> tipoComissaoRepository)
    {
        _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
    
        RuleFor(x => x.Id)
        .NotEmpty()
        .Must(ToExistTipoComissao)
        .WithMessage("O tipo de Comissão deve existir no banco");
    }

    private bool ToExistTipoComissao(Guid tipoComissaoId){
        var result = _tipoComissaoRepository.Get(tipoComissaoId);

        if(result == null)
            return false;

        return true;
    }
}