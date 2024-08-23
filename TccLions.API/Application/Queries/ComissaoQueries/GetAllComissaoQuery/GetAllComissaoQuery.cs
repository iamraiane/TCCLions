using MediatR;
using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;

public class GetAllComissaoQuery : IRequest<IEnumerable<ComissaoDTO>>
{
    public string NomeDoMembro { get; set; }
    public string TipoComissao { get; set; }
}
