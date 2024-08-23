using MediatR;

namespace TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand
{
    public class UpdateComissaoCommand : IRequest<bool?>
    {
        public Guid Id { get; set; }
        public Guid TipoComissaoId { get; set; }
    }
}
