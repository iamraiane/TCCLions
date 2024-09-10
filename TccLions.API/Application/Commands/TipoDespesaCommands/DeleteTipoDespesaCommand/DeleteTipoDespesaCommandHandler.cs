using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.TipoDespesaCommands.DeleteTipoDespesaCommand
{
    public class DeleteTipoDespesaCommandHandler : IRequestHandler<DeleteTipoDespesaCommand, bool>
    {
        private readonly ITipoDespesaRepository _tipoDespesaRepository;
        public DeleteTipoDespesaCommandHandler(ITipoDespesaRepository tipoDespesaRepository){
            _tipoDespesaRepository = tipoDespesaRepository ?? throw new ArgumentNullException(nameof(tipoDespesaRepository));
        }
        
        public async Task<bool> Handle(DeleteTipoDespesaCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var tipoDespesa = _tipoDespesaRepository.Get(request.Id);

            _tipoDespesaRepository.Remove(tipoDespesa);

            return await _tipoDespesaRepository.SaveChangesAsync();
        }
    
    }
}