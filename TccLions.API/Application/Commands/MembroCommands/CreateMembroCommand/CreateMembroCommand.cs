using MediatR;

namespace TCCLions.API.Application.Commands.MembroCommands.CreateMembroCommand;

public class CreateMembroCommand : IRequest<Guid?>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int EstadoCivilId { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
}
