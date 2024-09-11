using MediatR;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoComissaoQueries.GetTipoComissaoQuery;

public class GetTipoComissaoByIdQuery : IRequest<TipoComissaoDTO>
{
    public Guid Id {get; set;}
}