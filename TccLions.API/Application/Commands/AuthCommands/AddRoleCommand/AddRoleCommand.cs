using MediatR;

namespace TCCLions.API.Application.Commands.AuthCommands.AddRoleCommand;

public class AddRoleCommand : IRequest<bool>
{
    public Guid MembroId { get; set; }
    public string NomePermissao { get; set; }
}
