namespace TCCLions.API.Application.Models.ViewModels;

public class PaginatedItemsViewModel<T>
{
    public int TamanhoDaPagina { get; set; }
    public int IndiceDaPagina { get; set; }
    public int Quantidade { get; set; }
    public IEnumerable<T> Dados { get; set; }
}
