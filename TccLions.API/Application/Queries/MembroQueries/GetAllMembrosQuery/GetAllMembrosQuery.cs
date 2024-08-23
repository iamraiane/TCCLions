using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.MembroQueries.GetAllMembrosQuery;

public class GetAllMembrosQuery : IRequest<IEnumerable<MembroDTO>>
{
    public string NomeDoMembro { get; set; }
}
