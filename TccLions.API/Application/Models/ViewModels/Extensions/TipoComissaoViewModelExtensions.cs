using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Models.ViewModels.Extensions
{
    public static class TipoComissaoViewModelExtensions
    {
        public static TipoComissaoViewModel ToViewModel (this TipoComissaoDTO dto ){
            return new TipoComissaoViewModel  { Id = dto.Id, Descricao = dto.Descricao};
        }
    }
}