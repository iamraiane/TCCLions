using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.AtasQueries.GetAtaById;

public class GetAtaByIdQuery : IRequest<AtaDTO>
{
    public Guid Id { get; set; }
}
