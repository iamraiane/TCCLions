using FluentValidation;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.UpdateTipoComissaoCommand;

public class UpdateTipoComissaoCommandHandlerValidation : AbstractValidator<UpdateTipoComissaoCommand>
{
    private IRepositoryBase<TipoComissao, Guid> _tipoComissaoRepository;

    public UpdateTipoComissaoCommandHandlerValidation(IRepositoryBase<TipoComissao, Guid> tipoComissaoRepository){
        _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));

        RuleFor(x => x.Id)
        .NotEmpty()
        .Must(ToExistTipoComissao)
        .WithMessage("O tipo de comissão deve existir no banco de dados");

        RuleFor(x => x.Descricao)
        .NotEmpty()
        .WithMessage("O atributo descrição não pode ser vazio")
        .MaximumLength(255)
        .WithMessage("O atributo descrição não pode ter mais que 255 caracteres");

    }

    private bool ToExistTipoComissao(Guid tipoComissaoId){
        var result = _tipoComissaoRepository.Get(tipoComissaoId);

        if(result == null)
            return false;

        return true;
    }
}