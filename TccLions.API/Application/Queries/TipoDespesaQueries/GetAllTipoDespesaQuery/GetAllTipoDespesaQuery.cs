using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetAllTipoDespesaQuery;

public class GetAllTipoDespesaQuery : IRequest<IEnumerable<TipoDeDespesaDTO>>
{
    
}