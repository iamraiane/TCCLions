using MediatR;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.API.Application.Queries.AtasQueries.GetAtaById;

public class GetAtaByIdQueryHandler(IRepositoryBase<Ata, Guid> repository) : IRequestHandler<GetAtaByIdQuery, AtaDTO>
{
    private readonly IRepositoryBase<Ata, Guid> _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 
    public Task<AtaDTO> Handle(GetAtaByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var ata = _repository.Get(request.Id);

        if (ata is null)
            return null;

        return Task.FromResult(new AtaDTO
        {
            Id = ata.Id,
            DataEscrita = ata.DataEscrita,
            Descricao = ata.Descricao,
            Titulo = ata.Titulo
        });
    }
}
