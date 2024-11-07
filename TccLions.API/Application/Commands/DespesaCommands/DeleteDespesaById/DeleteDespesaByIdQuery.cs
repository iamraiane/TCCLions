using MediatR;

namespace TCCLions.API.Application.Commands.DespesaCommands.DeleteDespesaById;

public class DeleteDespesaByIdQuery : IRequest<bool?>
{
    public Guid Id { get; set; }
}
