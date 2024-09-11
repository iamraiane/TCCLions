using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.AtasQueries.GetAllAtas;

public class GetAllAtasQueryHandler(IRepositoryBase<Ata, Guid> repository) : IRequestHandler<GetAllAtasQuery, IEnumerable<AtaDTO>>
{
    private readonly IRepositoryBase<Ata, Guid> _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    public Task<IEnumerable<AtaDTO>> Handle(GetAllAtasQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var data = _repository.GetAll().Select(_ => new AtaDTO
        {
            Id = _.Id,
            Titulo = _.Titulo,
            DataEscrita = _.DataEscrita,
            Descricao = _.Descricao,
        });

        return Task.FromResult(data);
    }
}
