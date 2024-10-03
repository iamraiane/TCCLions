using MediatR;

namespace TCCLions.API.Application.Commands.AtaCommands.CreateAta;

public class CreateAtaCommand : IRequest<bool>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataEscrita { get; set; }
}
