using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoComissaoCommands.CreateTipoComissaoCommand
{
    public class CreateTipoComissaoCommandHandler(ITipoComissaoRepository repository) : IRequestHandler<CreateTipoComissaoCommand, Guid?>
    {
        private readonly ITipoComissaoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<Guid?> Handle(CreateTipoComissaoCommand request, CancellationToken cancellationToken){

            ArgumentNullException.ThrowIfNull(request);

            var tipoComissao = new TipoComissao(request.Descricao);

            repository.Create(tipoComissao);

            if(!await _repository.SaveChangesAsync())
                return null;

            return tipoComissao.Id;
        }

    }
}