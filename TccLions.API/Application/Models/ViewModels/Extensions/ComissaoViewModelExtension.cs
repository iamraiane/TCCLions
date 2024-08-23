using TCCLions.API.Application.Models.DTOs;

namespace TCCLions.API.Application.Models.ViewModels.Extensions
{
    public static class ComissaoViewModelExtension
    {
        public static ComissaoViewModel ToViewModel(this ComissaoDTO dto)
        {
            return new ComissaoViewModel { Id = dto.Id, TipoComissao = dto.TipoComissao, NomeDoMembro = dto.NomeDoMembro };
        }
    }
}
