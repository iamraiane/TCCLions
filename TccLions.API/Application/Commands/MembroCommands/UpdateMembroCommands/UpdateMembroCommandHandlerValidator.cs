using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.MembroCommands.UpdateMembroCommands
{
    public class UpdateMembroCommandHandlerValidator : AbstractValidator<UpdateMembroCommand>
    {
        private IMembroRepository _membroRepository;
        public UpdateMembroCommandHandlerValidator(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository ?? throw new ArgumentException(nameof(membroRepository));

            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistMembro)
            .WithMessage("O membro deve existir no banco de dados.");

            RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O atributo nome não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage("O atributo nome não pode ter mais que 255 caracteres.");
        
           RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("O atributo email não pode ser vazio")
           .MaximumLength(255)
           .WithMessage("O atributo email não pode ter mais que 255 caracteres");

           RuleFor(x => x.Cpf)
           .NotEmpty()
           .WithMessage("O atributo Cpf não pode ser vazio")
           .MaximumLength(11)
           .WithMessage("O atributo Cpf não pode ter mais que 11 caracteres");
        }
        private bool ToExistMembro(Guid membroId){
            var result = _membroRepository.Get(membroId);

            if(result == null)
            return false;

            return true;
        }
    }
}