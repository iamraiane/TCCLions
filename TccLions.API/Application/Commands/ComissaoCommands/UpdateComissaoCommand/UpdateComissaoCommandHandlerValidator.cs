using FluentValidation;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand;

public class UpdateComissaoCommandHandlerValidator : AbstractValidator<UpdateComissaoCommand>
{
    private readonly IComissaoRepository _comissaoRepository;
    private readonly IRepositoryBase<TipoComissao, Guid> _tipoComissaoRepository;

    public UpdateComissaoCommandHandlerValidator(IRepositoryBase<TipoComissao, Guid> tipoComissaoRepository, IComissaoRepository comissaoRepository)
    {
        _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
        _comissaoRepository = comissaoRepository ?? throw new ArgumentNullException(nameof(comissaoRepository));

        RuleFor(_ => _.TipoComissaoId)
            .NotEmpty()
            .Must(ToExistTipoComissao)
            .WithMessage("O Tipo de Comissão deve existir no banco de dados.");

        RuleFor(_ => _.Id)
            .NotEmpty()
            .Must(ToExistComissao)
            .WithMessage("A Comissão deve existir no banco de dados.");
    }

    private bool ToExistTipoComissao(Guid tipoComissaoId)
    {
        var result = _tipoComissaoRepository.Get(tipoComissaoId);

        if (result is null)
            return false;

        return true;
    }

    private bool ToExistComissao(Guid comissaoId)
    {
        var result = _comissaoRepository.Get(comissaoId);

        if (result is null)
            return false;

        return true;
    }
}
