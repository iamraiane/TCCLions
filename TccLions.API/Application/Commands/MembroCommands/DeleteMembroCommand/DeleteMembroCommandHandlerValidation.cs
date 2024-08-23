using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand
{
    public class DeleteMembroCommandHandlerValidation : AbstractValidator<DeleteMembroCommand>
    {
        private readonly IMembroRepository _membroRepository;
        public DeleteMembroCommandHandlerValidation(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository ?? throw new ArgumentException(nameof(membroRepository));

            RuleFor(x => x.Id)
            .NotEmpty()
            .Must(ToExistMembro)
            .WithMessage("O membro deve existir no banco");

        }

        private bool ToExistMembro(Guid membroId){
            var result = _membroRepository.Get(membroId);

            if(result == null)
            return false;

            return true;
        }
    }
}