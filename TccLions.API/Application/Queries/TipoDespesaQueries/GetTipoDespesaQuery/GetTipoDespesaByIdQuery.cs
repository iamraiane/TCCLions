using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetTipoDespesaQuery
{
    public class GetTipoDespesaByIdQuery : IRequest<TipoDeDespesaDTO>
    {
        public Guid Id {get; set;}
    }
}