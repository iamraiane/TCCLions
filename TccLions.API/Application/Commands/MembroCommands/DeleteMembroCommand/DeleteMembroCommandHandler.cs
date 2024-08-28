using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand
{
    public class DeleteMembroCommandHandler : IRequestHandler<DeleteMembroCommand, bool>
    {
        private readonly IMembroRepository _membroRepository;
        public DeleteMembroCommandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }        
        public async Task<bool> Handle(DeleteMembroCommand request, CancellationToken cancellationToken){
            ArgumentNullException.ThrowIfNull(request);

            var membro = _membroRepository.Get(request.Id);

            _membroRepository.Remove(membro);

            return await _membroRepository.SaveChangesAsync();
        }
    }
}