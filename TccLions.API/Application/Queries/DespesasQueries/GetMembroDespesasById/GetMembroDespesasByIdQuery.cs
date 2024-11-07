using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.DespesasQueries.GetMembroDespesasById;

public class GetMembroDespesasByIdQuery : IRequest<MembroDTO>
{
    public Guid MembroId { get; set; }
}
