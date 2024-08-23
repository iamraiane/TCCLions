namespace TCCLions.API.Application.Models.Requests.Common;

public class PaginationFilterRequest
{
    private int TAMANHO_DE_PAGINA_PADRAO = 50;
    public PaginationFilterRequest()
    {
        IndiceDaPagina = 0;
        TamanhoDaPagina = TAMANHO_DE_PAGINA_PADRAO;
    }
    public int TamanhoDaPagina { get; set; }
    public int IndiceDaPagina { get; set; }
}
