using FluentValidation;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand
{
    public class DeleteComissaoCommandHandlerValidator : AbstractValidator<DeleteComissaoCommand>
    {
        private readonly IComissaoRepository _comissaoRrepository;

        public DeleteComissaoCommandHandlerValidator(IComissaoRepository comissaoRepository)
        {
            _comissaoRrepository = comissaoRepository ?? throw new ArgumentNullException(nameof(comissaoRepository));

            RuleFor(_ => _.Id)
                .NotEmpty()
                .Must(ToExistComissao)
                .WithMessage("A Comissão deve existir no banco de dados.");
        }

        private bool ToExistComissao(Guid comissaoId)
        {
            var result = _comissaoRrepository.Get(comissaoId);

            if (result is null)
                return false;

            return true;
        }
    }
}
