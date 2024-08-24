using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.MembroQueries.GetAllMembrosQuery;

public class GetAllMembrosQueryHandler(IMembroRepository repository) : IRequestHandler<GetAllMembrosQuery, IEnumerable<MembroDTO>>
{
    private readonly IMembroRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<IEnumerable<MembroDTO>> Handle(GetAllMembrosQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(request));

        var data = _repository.GetAll()
            .Where(x => request.NomeDoMembro is null || x.Nome.Contains(request.NomeDoMembro, StringComparison.CurrentCultureIgnoreCase))
            .Select(x => new MembroDTO { 
                Id = x.Id,
                Bairro = x.Bairro,
                Cep = x.Cep,
                Cidade = x.Cidade,
                Cpf = x.Cpf,
                Email = x.Email,
                Endereco = x.Endereco,
                EstadoCivil = x.EstadoCivil,
                Nome = x.Nome,
                IsActive = x.IsActive
            });

        return Task.FromResult(data);
    }
}
