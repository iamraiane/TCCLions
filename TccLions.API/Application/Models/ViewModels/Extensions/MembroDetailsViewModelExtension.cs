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
            Email = dto.Email,
            Cpf = dto.Cpf,
            EstadoCivil = dto.EstadoCivil,
            IsActive = dto.IsActive,
            Permissoes = dto.Permissoes?.Select(_ => _.Nome),
            Enderecos = dto.Enderecos?.Select(_ => new EnderecoViewModel
            {
                Numero = _.Numero,
                Logradouro = _.Logradouro,
                Estado = _.Estado,
                Cidade = _.Cidade,
                Bairro = _.Bairro,
                Cep = _.Cep
            })
        };
    }
}
