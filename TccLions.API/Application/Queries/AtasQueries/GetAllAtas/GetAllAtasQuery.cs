using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.AtasQueries.GetAllAtas;

public class GetAllAtasQuery : IRequest<IEnumerable<AtaDTO>>
{
}
