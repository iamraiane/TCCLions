using FluentValidation;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.CreateComissaoCommand;

public class CreateComissaoCommandHandlerValidator : AbstractValidator<CreateComissaoCommand>
{
    private readonly ITipoComissaoRepository _tipoComissaoRepository;
    private readonly IMembroRepository _membroRepository;
    public CreateComissaoCommandHandlerValidator(ITipoComissaoRepository tipoComissaoRepository, IMembroRepository membroRepository)
    {
        _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
        _membroRepository = membroRepository ?? throw new ArgumentNullException(nameof(membroRepository));

        RuleFor(_ => _.TipoComissaoId)
            .NotEmpty()
            .Must(ToExistTipoComissao)
            .WithMessage("O Tipo de Comissão deve existir no banco de dados.");

        RuleFor(_ => _.MembroId)
            .NotEmpty()
            .Must(ToExistMembro)
            .WithMessage("O Membro deve existir no banco de dados.");
    }

    private bool ToExistTipoComissao(Guid tipoComissaoId)
    {
        return _tipoComissaoRepository.Get(tipoComissaoId) != null;
    }

    private bool ToExistMembro(Guid membroId)
    {
        return _membroRepository.Get(membroId) != null; 
    }
}
