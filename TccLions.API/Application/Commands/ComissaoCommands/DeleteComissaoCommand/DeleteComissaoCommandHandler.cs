using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand
{
    public class DeleteComissaoCommandHandler : IRequestHandler<DeleteComissaoCommand, bool>
    {
        private readonly IComissaoRepository _comissaoRepository;

        public DeleteComissaoCommandHandler(IComissaoRepository comissaoRepository)
        {
            _comissaoRepository = comissaoRepository;
        }

        public async Task<bool> Handle(DeleteComissaoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var comissao = _comissaoRepository.Get(request.Id);

            _comissaoRepository.Remove(comissao);

            return await _comissaoRepository.SaveChangesAsync();
        }
    }
}
