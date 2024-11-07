namespace TCCLions.API.Application.Models.ViewModels;

public class DespesaViewModel
{
    public Guid Id { get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
    public string TipoDeDespesa { get; set; }
}
