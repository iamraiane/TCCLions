using MediatR;

namespace TCCLions.API.Application.Commands.MembroCommands.DisableMembro;

public class EnableMembroCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
