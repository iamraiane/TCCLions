using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.UpdateTipoDespesaCommand
{
    public class UpdateTipoDespesaCommandHandler : IRequestHandler<UpdateTipoDespesaCommand, bool?>
    {
        private ITipoDespesaRepository _tipoDespesaRepository;
        public UpdateTipoDespesaCommandHandler(ITipoDespesaRepository tipoDespesaRepository)
        {
            _tipoDespesaRepository = tipoDespesaRepository ?? throw new ArgumentNullException(nameof(tipoDespesaRepository));
        }
        public async Task<bool?> Handle(UpdateTipoDespesaCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoDespesa = _tipoDespesaRepository.Get(request.Id);

            tipoDespesa.Update(request.Descricao);

            return await _tipoDespesaRepository.SaveChangesAsync();
        }
    }
}