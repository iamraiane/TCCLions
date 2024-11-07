using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels;

public class MembroDespesasViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<DespesaViewModel> Despesas { get; set; }
}
