using TCCLions.API.Application.Models.Requests.Common;

namespace TCCLions.API.Application.Models.Requests.Membro.Filters;

public class MembroFilterRequest : PaginationFilterRequest
{
    public string NomeDoMembro { get; set; }
    public bool MostrarDesabilitados { get; set; }
}
