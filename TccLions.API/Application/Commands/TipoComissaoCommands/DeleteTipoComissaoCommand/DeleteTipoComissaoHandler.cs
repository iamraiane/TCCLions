using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.DeleteTipoComissaoCommand
{
    public class DeleteTipoComissaoHandler : IRequestHandler<DeleteTipoComissaoCommand, bool>
    {
        private readonly ITipoComissaoRepository _tipoComissaoRepository;
        public DeleteTipoComissaoHandler(ITipoComissaoRepository tipoComissaoRepository)
        {
            _tipoComissaoRepository = tipoComissaoRepository;
        }
        public async Task<bool> Handle(DeleteTipoComissaoCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoComissao = _tipoComissaoRepository.Get(request.Id);

            _tipoComissaoRepository.Remove(tipoComissao);

            return await _tipoComissaoRepository.SaveChangesAsync();
        }
    }
}