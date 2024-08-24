using FluentValidation;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.MembroCommands.DisableMembro;

public class DisableMembroCommandValidator : AbstractValidator<DisableMembroCommand>
{
    public DisableMembroCommandValidator(IMembroRepository repository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("o Id do membro não pode ser nulo");
    }
}
