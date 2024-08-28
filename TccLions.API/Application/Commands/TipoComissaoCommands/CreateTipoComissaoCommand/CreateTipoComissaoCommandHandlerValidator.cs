using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.CreateTipoComissaoCommand
{
    public class CreateTipoComissaoCommandHandlerValidator : AbstractValidator<CreateTipoComissaoCommand>
    {
        public CreateTipoComissaoCommandHandlerValidator(){

            RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("O atributo descrição não pode ser vazio")
            .MaximumLength(255)
            .WithMessage("O atributo descrição não pode ter mais que 255 caracteres");
        }
    }
}