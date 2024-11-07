using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLions.API.Application.Models.DTOs;
using TCCLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Models.ViewModels.Extensions
{
    public static class TipoDespesaViewModelExtension
    {
        public static TipoDespesaViewModel ToViewModel (this TipoDeDespesaDTO dto){
            return new TipoDespesaViewModel { Id = dto.Id, Descricao = dto.Descricao};
        }
    }
}