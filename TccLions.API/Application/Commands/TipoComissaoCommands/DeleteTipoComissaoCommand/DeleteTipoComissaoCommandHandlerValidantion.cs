using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.DeleteTipoComissaoCommand
{
    public class DeleteTipoComissaoCommandHandlerValidantion : AbstractValidator<DeleteTipoComissaoCommand>
    {
        private readonly ITipoComissaoRepository _tipoComissaoRepository;
        public DeleteTipoComissaoCommandHandlerValidantion(ITipoComissaoRepository tipoComissaoRepository)
        {
            _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
        
            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistTipoComissao)
            .WithMessage("O tipo de comissão deve existir no banco");
        }

        private bool ToExistTipoComissao(Guid tipoComissaoId){

            var result = _tipoComissaoRepository.Get(tipoComissaoId);

            if(result == null)
                return false;

            return true;
        }
    }
}