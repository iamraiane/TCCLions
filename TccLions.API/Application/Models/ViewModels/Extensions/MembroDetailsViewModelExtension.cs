using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions;

public static class MembroDetailsViewModelExtension
{
    public static MembroDetailsViewModel ToDetailsViewModel(this MembroDTO dto)
    {
        return new MembroDetailsViewModel
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Bairro = dto.Bairro,
            Cep = dto.Cep,
            Cidade = dto.Cidade,
            Email = dto.Email,
            Cpf = dto.Cpf,
            Endereco = dto.Endereco,
            EstadoCivil = dto.EstadoCivil,
            IsActive = dto.IsActive,
            Permissoes = dto.Permissoes.Select(_ => new PermissaoViewModel
            {
                Nome = _.Nome
            })
        };
    }
}
