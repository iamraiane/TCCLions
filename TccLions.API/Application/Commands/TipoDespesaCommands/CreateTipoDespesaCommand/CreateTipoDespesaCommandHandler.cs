using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.Domain.Data.Models;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.CreateTipoDespesaCommand
{
    public class CreateTipoDespesaCommandHandler(ITipoDespesaRepository repository) : IRequestHandler<CreateTipoDespesaCommand, Guid?>
    {
        private readonly ITipoDespesaRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<Guid?> Handle(CreateTipoDespesaCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoDespesa = new TipoDespesa(request.Descricao);

            _repository.Create(tipoDespesa);

            if(!await _repository.SaveChangesAsync())
                return null;

            return tipoDespesa.Id;
        }
    }
}