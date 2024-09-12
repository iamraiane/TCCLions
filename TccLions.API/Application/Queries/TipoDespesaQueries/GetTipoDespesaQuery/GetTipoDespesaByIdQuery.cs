using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoDespesaQueries.GetTipoDespesaQuery
{
    public class GetTipoDespesaByIdQuery : IRequest<TipoDespesaDTO>
    {
        public Guid Id {get; set;}
    }
}