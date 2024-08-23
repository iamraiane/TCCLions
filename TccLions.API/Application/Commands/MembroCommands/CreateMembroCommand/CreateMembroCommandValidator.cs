using FluentValidation;

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

        RuleFor(x => x.EstadoCivil).MaximumLength(100)
            .WithMessage("O estado civil informado é muito longo.");

        RuleFor(x => x.Cep).MinimumLength(9)
            .MaximumLength(9)
            .WithMessage("O CEP deve ter exatamente 9 caractéres.");

        RuleFor(x => x.Cpf).Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
            .WithMessage("O CPF informado é inválido.");
    }
}
