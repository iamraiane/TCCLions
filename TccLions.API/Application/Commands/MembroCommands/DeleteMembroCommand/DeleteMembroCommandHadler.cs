using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Repositories;
using MediatR;

namespace TccLions.API.Application.Commands.MembroCommands.DeleteMembroCommand
{
    public class DeleteMembroCommandHadler : IRequestHandler<DeleteMembroCommand, bool>
    {
        private readonly IMembroRepository _membroRepository;

        public DeleteMembroCommandHadler(IMembroRepository membroRepository)
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