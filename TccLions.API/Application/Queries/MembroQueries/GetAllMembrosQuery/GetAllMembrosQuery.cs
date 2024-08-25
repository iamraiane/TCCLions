using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.MembroQueries.GetAllMembrosQuery;

public class GetAllMembrosQuery : IRequest<IEnumerable<MembroDTO>>
{
    public string NomeDoMembro { get; set; }
    public bool MostrarDesabilitados { get; set; }
    public int TamanhoDaPagina { get; set; }
    public int IndiceDaPagina { get; set; }
}
