using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.EventoCommands.UpdateEventoCommand
{
    public class UpdateEventoCommandHandlerValidation : AbstractValidator<UpdateEventoCommand>
    {
        private IEventoRepository _eventoRepository;
        public UpdateEventoCommandHandlerValidation(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository ?? throw new ArgumentNullException(nameof(eventoRepository));

            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistEvento)
            .WithMessage("O evento deve existir no banco de dados.");

            RuleFor(x => x.NomeEvento)
            .NotEmpty()
            .WithMessage("O atributo nome evento não pode ser vazio")
            .MaximumLength(255)
            .WithMessage("O atributo nome evento não pode ter mais que 255 caracteres.");

            RuleFor(x => x.QuantidadeVenda)
            .NotEmpty()
            .WithMessage("O atributo Quantidade de venda não pode ser vazio.");
        
            RuleFor(x => x.DataVenda)
            .NotEmpty()
            .WithMessage("O atributo Data Venda não pode ser vazio");

            RuleFor(x => x.ValorTotal)
            .NotEmpty()
            .WithMessage("O atributo valor total não pode ser vazio");
    
      }

        private bool ToExistEvento(Guid eventoId){
            
            var result = _eventoRepository.Get(eventoId);

            if(result == null)
                return false;

            return true;
        }
    }
}