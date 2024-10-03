using MediatR;

namespace TCCLions.API.Application.Commands.AtaCommands.UpdateAta;

public class UpdateAtaCommand : IRequest<bool?>
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataEscrita { get; set; }
    public string Descricao { get; set; }
}
