using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.MembroQueries.GetMembroQuery;

public class GetMembroByIdQuery : IRequest<MembroDTO>
{
    public Guid Id { get; set; }
}
