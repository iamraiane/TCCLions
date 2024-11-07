using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class DespesaViewModelExtension
{
    public static DespesaViewModel ToViewModel(this DespesaDTO dto)
    {
        return new DespesaViewModel
        {
            Id = dto.Id,
            DataVencimento = dto.DataVencimento,
            DataRegistro = dto.DataRegistro,
            ValorTotal = dto.ValorTotal,
            TipoDeDespesa = dto.TipoDeDespesa.Descricao
        };
    }
}
