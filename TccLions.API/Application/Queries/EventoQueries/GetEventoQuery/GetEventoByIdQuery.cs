using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Queries.EventoQueries.GetEventoQuery
{
    public class GetEventoByIdQuery : IRequest<EventoDTO>
    {
        public Guid Id {get; set;}
    }
}