using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.CreateComissaoCommand
{
    public class CreateComissaoCommandHandler(IComissaoRepository repository) : IRequestHandler<CreateComissaoCommand, Guid?>
    {
        private readonly IComissaoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<Guid?> Handle(CreateComissaoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var comissao = new Comissao(request.TipoComissaoId, request.MembroId);

            _repository.Create(comissao);

            if (!await _repository.SaveChangesAsync())
                return null;

            return comissao.Id;
        }
    }
}
