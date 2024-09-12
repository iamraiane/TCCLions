using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace TccLions.API.Application.Commands.EventoCommands.CreateEventoCommand
{
    public class CreateEventoCommandHandlerValidator : AbstractValidator<CreateEventoCommand>
    {
        public CreateEventoCommandHandlerValidator()
        {
            RuleFor(x => x.NomeEvento)
            .NotEmpty()
            .WithMessage("O atributo Nome Evento não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage("O atributo Nome Evento não pode ter mais que 255 caracteres");

            RuleFor(x => x.QuantidadeVenda)
            .NotEmpty()
            .WithMessage("O atrbito quantidade venda não pode ser vazio.");

            RuleFor(x => x.DataVenda)
            .NotEmpty()
            .WithMessage("O atributo Data Venda não pode ser vazio");

            RuleFor(x => x.ValorTotal)
            .NotEmpty()
            .WithMessage("O atributo Valor Total não pode ser vazio");
        }
    }
}