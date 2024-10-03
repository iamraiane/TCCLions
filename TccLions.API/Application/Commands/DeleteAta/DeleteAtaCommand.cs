using MediatR;

namespace TCCLions.API.Application.Commands.DeleteAta;

public class DeleteAtaCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
