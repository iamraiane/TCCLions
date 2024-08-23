using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;

public class GetComissaoQuery : IRequest<ComissaoDTO>
{
    public Guid Id { get; set; }
}
