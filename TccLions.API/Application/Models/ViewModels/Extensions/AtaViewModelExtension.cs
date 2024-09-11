using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class AtaViewModelExtension
{
    public static AtaViewModel ToViewModel(this AtaDTO dto)
    {
        return new AtaViewModel
        {
            DataEscrita = dto.DataEscrita,
            Descricao = dto.Descricao,
            Id = dto.Id,
            Titulo = dto.Titulo
        };
    }
}
