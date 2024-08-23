using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.MembroQueries.GetMembroQuery;

public class GetMembroByIdQueryHandler(IMembroRepository repository) : IRequestHandler<GetMembroByIdQuery, MembroDTO>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<MembroDTO> Handle(GetMembroByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var membro = _repository.Get(request.Id);

        if (membro is null)
            return Task.FromResult((MembroDTO)null);

        return Task.FromResult(new MembroDTO {
            Id = membro.Id,
            Bairro = membro.Bairro,
            Cep = membro.Cep,
            Cidade = membro.Cidade,
            Cpf = membro.Cpf,
            Email = membro.Email,
            Endereco = membro.Endereco,
            EstadoCivil = membro.EstadoCivil,
            Nome = membro.Nome
        });
    }
}
