using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class MembroViewModelExtension
{
    public static MembroViewModel ToViewModel(this MembroDTO dto)
    {
        return new MembroViewModel
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Email = dto.Email,
            EstadoCivil = dto.EstadoCivil,
            IsActive = dto.IsActive
        };
    }
}
