using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.DeleteTipoDespesaCommand
{
    public class DeleteTipoDespesaCommandHandlerValidation : AbstractValidator<DeleteTipoDespesaCommand>
    {
        private readonly ITipoDespesaRepository _tipoDespesaRepository;
        public DeleteTipoDespesaCommandHandlerValidation(ITipoDespesaRepository tipoDespesaRepository)
        {
            _tipoDespesaRepository = tipoDespesaRepository ?? throw new ArgumentNullException(nameof(tipoDespesaRepository));

            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistTipoDespesa)
            .WithMessage("O Tipo de Despesa deve existir no banco de dados.");
        } 
        private bool ToExistTipoDespesa(Guid id){
            var result = _tipoDespesaRepository.Get(id);

            if(result == null)
                return false;

            return true;
        }
    }
}