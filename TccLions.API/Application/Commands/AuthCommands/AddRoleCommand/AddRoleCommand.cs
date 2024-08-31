using MediatR;

namespace TCCLions.API.Application.Commands.AuthCommands.SetAdminCommand;

public class AddRoleCommand : IRequest<bool>
{
    public Guid MembroId { get; set; }
    public string NomePermissao { get; set; }
}
