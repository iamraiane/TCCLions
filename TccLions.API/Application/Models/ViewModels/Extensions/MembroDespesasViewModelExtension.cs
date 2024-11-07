using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class MembroDespesasViewModelExtension
{
    public static MembroDespesasViewModel ToDespesasViewModel(this MembroDTO dto)
    {
        return new MembroDespesasViewModel
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Despesas = dto.Despesas.Select(d => d.ToViewModel())
        };
    }
}
