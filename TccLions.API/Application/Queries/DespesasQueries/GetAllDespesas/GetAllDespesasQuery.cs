using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.DespesasQueries.GetAllDespesas;

public class GetAllDespesasQuery : IRequest<IEnumerable<MembroDTO>>
{
}
