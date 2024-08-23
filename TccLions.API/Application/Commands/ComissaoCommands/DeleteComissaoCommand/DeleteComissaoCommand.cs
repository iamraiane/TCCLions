using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand
{
    public class DeleteComissaoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
