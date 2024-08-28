using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.UpdateTipoComissaoCommand
{
    public class UpdateTipoComissaoCommandHandler : IRequestHandler<UpdateTipoComissaoCommand, bool?>
    {
        private ITipoComissaoRepository _tipoComissaoRepository;

        public UpdateTipoComissaoCommandHandler(ITipoComissaoRepository tipoComissaoRepository)
        {
            _tipoComissaoRepository = tipoComissaoRepository ?? throw new ArgumentNullException(nameof(tipoComissaoRepository));
        }

        public async Task<bool?> Handle(UpdateTipoComissaoCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoComissao = _tipoComissaoRepository.Get(request.Id);

            tipoComissao.Update(request.Descricao);

            return await _tipoComissaoRepository.SaveChangesAsync();
        }
    }
}