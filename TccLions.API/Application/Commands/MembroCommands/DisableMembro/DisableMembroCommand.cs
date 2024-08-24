using MediatR;

namespace TCCLions.API.Application.Commands.MembroCommands.DisableMembro;

public class DisableMembroCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
