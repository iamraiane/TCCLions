using FluentValidation;
using TCCLions.Domain.Data.Models;

namespace TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;

public class CreateMembroCommandValidator : AbstractValidator<CreateMembroCommand>
{
    public CreateMembroCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress()
            .WithMessage("O email informado é inválido.")
            .MaximumLength(255)
            .WithMessage("O email informado é muito longo.");

        RuleFor(x => x.Nome).MinimumLength(3)
            .WithMessage("O nome informado é muito curto.")
            .MaximumLength(255)
            .WithMessage("O nome informado é muito longo.");

        RuleFor(x => x.Endereco).MaximumLength(255)
            .WithMessage("O endereço informado é muito longo.");

        RuleFor(x => x.Bairro).MaximumLength(255)
            .WithMessage("O bairro informado é muito longo.");

        RuleFor(x => x.Cidade).MaximumLength(255)
            .WithMessage("A cidade informada é muito longa.");

        RuleFor(x => x.Cep).MinimumLength(8)
            .MaximumLength(8)
            .WithMessage("O CEP deve ter exatamente 8 caractéres.");

        RuleFor(x => x.Cpf)
          .NotEmpty()
          .WithMessage("O atributo Cpf não pode ser vazio")
          .MaximumLength(11)
          .WithMessage("O atributo Cpf não pode ter mais que 11 caracteres");

        RuleFor(x => x.EstadoCivilId)
            .NotEmpty()
            .WithMessage("O Estado Civil não pode ser vazio")
            .Must(estadoCivilId => Enum.IsDefined(typeof(EstadoCivilEnum), estadoCivilId))
            .WithMessage("O Estado Civil deve existir no banco de dados");
    }
}
