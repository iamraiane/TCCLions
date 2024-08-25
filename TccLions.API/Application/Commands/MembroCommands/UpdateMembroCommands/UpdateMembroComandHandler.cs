using MediatR;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TccLions.API.Application.Commands.MembroCommands.UpdateMembroCommands
{
    public class UpdateMembroComandHandler : IRequestHandler<UpdateMembroCommand, bool?>
    {
        private IMembroRepository _membroRepository;
        public UpdateMembroComandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public async Task<bool?> Handle(UpdateMembroCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var membro = _membroRepository.Get(request.Id);

            membro.Update(request.Nome, request.Endereco, request.Bairro, request.Cidade,
            request.Cep, request.Email, (EstadoCivilEnum)Enum.ToObject(typeof(EstadoCivilEnum), request.EstadoCivilId), request.Cpf);
            
            return await _membroRepository.SaveChangesAsync();
        }
    }
}