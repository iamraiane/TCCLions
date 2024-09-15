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
            Cpf = membro.Cpf,
            Email = membro.Email,
            EstadoCivil = membro.EstadoCivil.ToString(),
            Nome = membro.Nome,
            IsActive = membro.IsActive,
            Permissoes = membro.Permissoes.Select(_ => new PermissaoDTO
            {
                Id = _.Id,
                Nome = _.Nome,
            }),
            Enderecos = membro.Enderecos.Select(_ => new EnderecoDTO
            {
                Bairro = _.Bairro,
                Cep = _.Cep,
                Cidade = _.Cidade,
                Estado = _.Estado,
                Logradouro = _.Logradouro,
                Numero = _.Numero
            })
        });
    }
}
