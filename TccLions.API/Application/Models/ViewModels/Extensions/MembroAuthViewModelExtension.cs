using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class MembroAuthViewModelExtension
{
    public static MembroAuthViewModel ToAuthViewModel(this MembroDTO dto)
    {
        return new MembroAuthViewModel
        {
            Nome = dto.Nome,
            Id = dto.Id,
            Permissoes = dto.Permissoes?.Select(p => p.Nome)
        };
    }
}
