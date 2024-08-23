using MediatR;

namespace TCCLions.API.Application.Commands.ComissaoCommands.CreateComissaoCommand
{
    public class CreateComissaoCommand : IRequest<Guid?>
    {
        public Guid TipoComissaoId { get; set; }
        public Guid MembroId { get; set; }
    }
}
