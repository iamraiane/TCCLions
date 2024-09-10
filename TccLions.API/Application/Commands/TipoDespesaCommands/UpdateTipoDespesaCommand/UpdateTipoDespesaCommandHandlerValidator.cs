using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.UpdateTipoDespesaCommand
{
    public class UpdateTipoDespesaCommandHandlerValidator : AbstractValidator<UpdateTipoDespesaCommand>
    {
        private ITipoDespesaRepository _tipoDespesaRepository;
        public UpdateTipoDespesaCommandHandlerValidator(ITipoDespesaRepository tipoDespesaRepository)
        {
            _tipoDespesaRepository = tipoDespesaRepository ?? throw new ArgumentNullException(nameof(tipoDespesaRepository));
        
            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistTipoDespesa)
            .WithMessage("O tipo de despesa deve existir no banco de dados.");

            RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("O atributo descrição não pode ser vazio")
            .MaximumLength(255)
            .WithMessage("O atributo descrição não pode ter mais que 255 caracteres");

        
        }

        private bool ToExistTipoDespesa(Guid tipoDespesaId){
            var result = _tipoDespesaRepository.Get(tipoDespesaId);

            if(result == null)
                return false;

            return true;
        }
    }
}