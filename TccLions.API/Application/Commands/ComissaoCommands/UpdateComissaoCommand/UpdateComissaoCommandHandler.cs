using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand
{
    public class UpdateComissaoCommandHandler : IRequestHandler<UpdateComissaoCommand, bool?>
    {
        private readonly IComissaoRepository _comissaoRepository;

        public UpdateComissaoCommandHandler(IComissaoRepository comissaoRepository)
        {
            _comissaoRepository = comissaoRepository;
        }

        public async Task<bool?> Handle(UpdateComissaoCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var comissao = _comissaoRepository.Get(request.Id);

            comissao.Update(request.TipoComissaoId);

            return await _comissaoRepository.SaveChangesAsync();
        }
    }
}
