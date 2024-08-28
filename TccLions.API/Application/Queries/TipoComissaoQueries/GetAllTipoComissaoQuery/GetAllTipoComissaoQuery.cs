using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.TipoComissaoQueries.GetAllTipoComissaoQuery
{
    public class GetAllTipoComissaoQuery : IRequest<IEnumerable<TipoComissaoDTO>>
    {
        
    }
}